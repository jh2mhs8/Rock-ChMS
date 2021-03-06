-- Do these to make the output a little nicer
-- 1) Right Click | Results To > Results To Text
-- 2) Right Click | Query Options | Results | Text | 
---        uncheck 'Include Column Headers...'      
---        change 'maximum number of characters...' to 9999

set nocount on
declare
@codetext nvarchar(max) = ''

begin

    select @codetext = @codetext + '// Migration Up()' + char(13)
    
    -- pages
    SELECT @codetext = @codetext +
        CONCAT('            AddPage("',
        [parentPage].[Guid], '","', 
        [p].[Name],  '","',  
        [p].[Description],  '","',
        [p].[Guid], '");') + char(13) 
    FROM 
      [Page] p
    join [Page] [parentPage] on [p].[ParentPageId] = [parentPage].[Id]
    where [p].[IsSystem] = 0
    order by [p].[Id]

    -- block types
    select @codetext = @codetext + 
        CONCAT('            AddBlockType("',
        [Name], '","',  
        [Description], '","',  
        [Path], '","',  
        [Guid], '");') + char(13) 
    from [BlockType]
    where [IsSystem] = 0
    order by [Id]

    -- blocks
    select @codetext = @codetext + 
        CONCAT('            AddBlock("',
        [p].[Guid], '","', 
        [bt].[Guid], '","',
        [b].[Name], '","',
        [b].[Zone], '","',
        [b].[Guid], '",',
        [b].[Order], ');') + char(13)  
    from [Block] [b]
    join [Page] [p] on [p].[Id] = [b].[PageId]
    join [BlockType] [bt] on [bt].[Id] = [b].[BlockTypeId]
    where 
      [b].[IsSystem] = 0
    order by [b].[Id]

    -- attributes
    if object_id('tempdb..#attributeIds') is not null
    begin
      drop table #attributeIds
    end

    select * into #attributeIds from (select [Id] from [dbo].[Attribute] where [IsSystem] = 0) [newattribs]

    select @codetext = @codetext +
        CONCAT('            AddBlockTypeAttribute("', 
        bt.Guid, '","',   
        ft.Guid, '","',   
        a.name, '","',  
        a.[Key], '","', 
        a.Category, '","', 
        a.Description, '",', 
        a.[Order], ',"', 
        a.DefaultValue, '","', 
        a.Guid, '");') + char(13)  
    from [Attribute] [a]
    left outer join [FieldType] [ft] on [ft].[Id] = [a].[FieldTypeId]
    left outer join [BlockType] [bt] on [bt].[Id] = cast([a].[EntityTypeQualifierValue] as int)
    where EntityTypeQualifierColumn = 'BlockTypeId'
    and [a].[id] in (select [Id] from #attributeIds)

    -- attributes values    
    select @codetext = @codetext + 
        CONCAT('            // Attrib Value for ', b.Name, ':', a.Name,
        CHAR(13),
        '            AddBlockAttributeValue("',     
        b.Guid, '","', 
        a.Guid, '","', 
        av.Value, '");',
        CHAR(13)  )
    from [AttributeValue] [av]
    join Block b on b.Id = av.EntityId
    join Attribute a on a.id = av.AttributeId
    where [av].[AttributeId] in (select [Id] from #attributeIds)

    drop table #attributeIds

	select @codetext [copy and paste me]

    select @codetext = '// Migration Down()' + char(13)

    select @codetext = @codetext + CONCAT('            DeleteAttribute("', [Guid], '");') + char(13)  from [Attribute] where [IsSystem] = 0 order by [Id]    
    select @codetext = @codetext + CONCAT('            DeleteBlock("', [Guid], '");') + char(13)  from [Block] where [IsSystem] = 0 order by [Id]
    select @codetext = @codetext + CONCAT('            DeleteBlockType("', [Guid], '");') + char(13)  from [BlockType] where [IsSystem] = 0 order by [Id]
    select @codetext = @codetext + CONCAT('            DeletePage("', [Guid], '");') + char(13)  from [Page] where [IsSystem] = 0 order by [Id] asc 

	select @codetext [copy and paste me]
end


