﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using NUnit.Framework;
using Rock.Model;

namespace Rock.Tests.Model
{
    [TestFixture]
    public class PageRouteTests
    {
        public class TheCopyPropertiesFromMethod
        {
            [Test]
            public void ShouldCopyEntity()
            {
                var pageRoute = new PageRoute { Guid = Guid.NewGuid() };
                var result = pageRoute.Clone( false );
                Assert.AreEqual( result.Guid, pageRoute.Guid );
            }
        }

        public class TheToJsonMethod
        {
            [Test]
            public void ShouldNotBeEmpty()
            {
                var pageRoute = new PageRoute { Guid = Guid.NewGuid() };
                dynamic result = pageRoute.ToJson();
                Assert.IsNotEmpty( result );
            }
        }

        public class TheFromJsonMethod
        {
            [Test]
            public void ShouldCopyPropertiesToEntity()
            {
                var obj = new PageRoute
                {
                    Route = "/some/path",
                    IsSystem = true
                };

                var json = obj.ToJson();
                var pageRoute = PageRoute.FromJson( json );
                Assert.AreEqual( obj.Route, pageRoute.Route );
                Assert.AreEqual( obj.IsSystem, pageRoute.IsSystem );
            }
        }
    }
}
