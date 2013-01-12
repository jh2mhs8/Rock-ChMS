﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rock.Model;

namespace Rock.Tests.Model
{
    [TestFixture]
    public class PageTests
    {
        public class TheCopyPropertiesFromMethod
        {
            [Test]
            public void ShouldCopyEntity()
            {
                var page = new Page { Name = "SomePage" };
                var result = page.Clone( false );
                Assert.AreEqual( result.Name, page.Name );
            }
        }

        public class TheCloneMethod
        {
            [Test]
            public void ShouldCopyPages()
            {
                var children = new List<Page> { new Page() };
                var parent = new Page { Pages = children };
                var result = parent.Clone() as Page;
                Assert.IsNotEmpty( result.Pages );
            }

            [Test]
            public void ShouldCopyPagesRecursively()
            {
                var parent = new Page();
                var child = new Page();
                var grandchild = new Page();
                parent.Pages = new List<Page> { child };
                child.Pages = new List<Page> { grandchild };
                var result = parent.Clone() as Page;
                Assert.IsNotEmpty( result.Pages );
                Assert.IsNotEmpty( result.Pages.FirstOrDefault().Pages );
            }

            [Test]
            public void ShouldCopyBlocks()
            {
                var page = new Page { Blocks = new List<Block>() };
                page.Blocks.Add( new Block() );
                var result = page.Clone() as Page;
                Assert.NotNull( result.Blocks );
                Assert.IsNotEmpty( result.Blocks );
            }

            [Test]
            public void ShouldCopyPageRoutes()
            {
                var page = new Page { PageRoutes = new List<PageRoute>() };
                page.PageRoutes.Add( new PageRoute() );
                var result = page.Clone() as Page;
                Assert.NotNull( result.PageRoutes );
                Assert.IsNotEmpty( result.PageRoutes );
            }

            [Test]
            public void ShouldCopyPageContexts()
            {
                var page = new Page { PageContexts = new List<PageContext>() };
                page.PageContexts.Add( new PageContext() );
                var result = page.Clone() as Page;
                Assert.NotNull( result.PageContexts );
                Assert.IsNotEmpty( result.PageContexts );
            }
        }

        public class TheToJsonMethod
        {
            [Test]
            public void ShouldNotBeEmpty()
            {
                var page = new Page();
                var result = page.ToJson();
                Assert.IsNotEmpty( result );
            }

            [Test]
            public void ShouldExportAsJson()
            {
                var page = new Page
                {
                    Title = "FooPage"
                };
                var result = page.ToJson();
                const string key = "\"Title\":\"FooPage\"";
                Assert.Greater( result.IndexOf( key ), -1 );
            }

            [Test]
            public void ShouldExportChildPages()
            {
                var page = new Page
                {
                    Title = "FooPage",
                    Pages = new List<Page> { new Page { Title = "BarPage" } }
                };
                var result = page.ToJson();
                result = result.Substring( result.IndexOf( "\"Pages\":" ) + 7 );
                const string key = "\"Title\":\"BarPage\"";
                Assert.Greater( result.IndexOf( key ), -1 );
            }

            [Test]
            public void ShouldExportChildPagesRecursively()
            {
                var parent = new Page { Title = "Parent" };
                var child = new Page { Title = "Child" };
                var grandchild = new Page { Title = "Grandchild" };
                parent.Pages = new List<Page> { child };
                child.Pages = new List<Page> { grandchild };
                var result = parent.ToJson( );
                const string parentKey = "\"Title\":\"Parent\"";
                const string childKey = "\"Title\":\"Child\"";
                const string grandChildKey = "\"Title\":\"Grandchild\"";
                Assert.Greater( result.IndexOf( parentKey ), -1 );
                Assert.Greater( result.IndexOf( childKey ), -1 );
                Assert.Greater( result.IndexOf( grandChildKey ), -1 );
            }
        }

        public class TheFromJsonMethod
        {
            [Test]
            public void ShouldCopyPropertiesToEntity()
            {
                var obj = new Page
                {
                    Name = "Foo Page",
                    IsSystem = true,
                };

                string json = obj.ToJson();
                var page = Page.FromJson( json );
                Assert.AreEqual( obj.Name, page.Name );
                Assert.AreEqual( obj.IsSystem, page.IsSystem );
            }

            [Test]
            public void ShouldImportChildPages()
            {
                var obj = new Page { Name = "Parent" };
                obj.Pages.Add ( new Page { Name = "Child" } );
                
                var json = obj.ToJson();
                var page = Page.FromJson( json );
                Assert.IsNotNull( page.Pages );
                Assert.IsNotEmpty( page.Pages );
                Assert.AreEqual( page.Pages.First().Name, obj.Pages.First().Name );
            }

            [Test]
            public void ShouldImportPagesRecursively()
            {
                const string PAGE_NAME = "Child Page";

                var childPage = new Page { Name = PAGE_NAME };
                var parentPage = new Page { Name = "Parent Page" };
                var grandparentPage = new Page { Name = "Grandparent Page" };

                parentPage.Pages.Add(childPage);
                grandparentPage.Pages.Add(parentPage);
 
                var json = grandparentPage.ToJson();
                var page = Page.FromJson( json );
                var childPages = page.Pages.First().Pages;
                Assert.IsNotNull( childPages );
                Assert.IsNotEmpty( childPages );
                Assert.AreEqual( childPages.First().Name, PAGE_NAME );
            }

            [Test]
            public void ShouldImportBlocks()
            {
                var obj = new Page { Name = "Some Page" };
                obj.Blocks.Add(new Block { Name = "Some Block" } );
                var json = obj.ToJson();
                var page = Page.FromJson( json );
                Assert.IsNotNull( page.Blocks );
                Assert.IsNotEmpty( page.Blocks );
                Assert.AreEqual( page.Blocks.First().Name, obj.Blocks.First().Name );
            }

            [Test]
            public void ShouldImportPageRoutes()
            {
                var obj = new Page { Name = "Some Page" };
                obj.PageRoutes.Add( new PageRoute { Route = "/some/route" } );
                var json = obj.ToJson();
                var page = Page.FromJson( json );
                Assert.IsNotNull( page.PageRoutes );
                Assert.IsNotEmpty( page.PageRoutes );
                Assert.AreEqual( page.PageRoutes.First().Route, obj.PageRoutes.First().Route );
            }

            [Test]
            public void ShouldImportPageContexts()
            {
                Random random = new Random();
                var id = random.Next();
                var obj = new Page { Name = "Some Page" };
                obj.PageContexts.Add( new PageContext { PageId = id } );
                var json = obj.ToJson();
                var page = Page.FromJson( json );
                Assert.IsNotNull( page.PageContexts );
                Assert.IsNotEmpty( page.PageContexts );
                Assert.AreEqual( page.PageContexts.First().PageId, id );
            }

            [Test]
            public void ShouldImportAttributes()
            {
                var obj = new Page
                {
                    Name = "Some Page",
                    Attributes = new Dictionary<string, Web.Cache.AttributeCache> { { "foobar", null } }
                };

                var json = obj.ToJson();
                var page = Page.FromJson( json );
                Assert.IsNotNull( page.Attributes );
                Assert.IsNotEmpty( page.Attributes );
                Assert.IsNull( page.Attributes.First().Value );
            }

            [Test]
            public void ShouldImportAttributeValues()
            {
                var obj = new Page
                {
                    Name = "Some Page",
                    AttributeValues = new Dictionary<string, List<AttributeValue>>
                    {
                        { "foobar", new List<AttributeValue> { new AttributeValue { Value = "baz" } } }
                    }
                };

                var json = obj.ToJson();
                var page = Page.FromJson( json );
                Assert.IsNotNull( page.AttributeValues );
                Assert.IsNotEmpty( page.AttributeValues );
                Assert.AreEqual( page.AttributeValues.First().Value.First().Value, "baz" );
            }
        }
    }
}
