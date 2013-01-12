//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rock.Communication
{
    interface IEmailProvider
    {

        /// <summary>
        /// Returns a list of bounced emails.  Paramenter tells whether soft bounces should also be returned.
        /// </summary>
        List<BouncedEmail> BouncedEmails( bool includeSoftBounces );

        /// <summary>
        /// Deletes bounced email from the email system
        /// </summary>
        bool DeleteBouncedEmail( string email );
    }
}
