/****** Script for SelectTopNRows command from SSMS  ******/
SELECT b.Id [Block.Id],
       p.[Title] [Page.Title], 
       b.[Name] [Block.Name],
       b.Zone [Block.Zone],
       b.Guid [Block.Guid],
       bt.[Name] [BlockType.Name],
       bt.[Guid] [BlockType.Guid],
       p.[Guid] [Page.Guid]
  FROM [Page] [p]
  join [Block] [b] on [p].[Id] = [b].[PageId]
  join [BlockType] [bt] on [bt].[Id] = [b].[BlockTypeId]
  order by b.Id, b.Name, p.Name