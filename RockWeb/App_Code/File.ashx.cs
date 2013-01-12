﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace RockWeb
{
    /// <summary>
    /// Handles retrieving file data from storage
    /// </summary>
    public class File : IHttpAsyncHandler
    {
        public File()
        {
        }

        /// <summary>
        /// Called to initialize an asynchronous call to the HTTP handler. 
        /// </summary>
        /// <param name="context">An HttpContext that provides references to intrinsic server objects used to service HTTP requests.</param>
        /// <param name="cb">The AsyncCallback to call when the asynchronous method call is complete.</param>
        /// <param name="extraData">Any state data needed to process the request.</param>
        /// <returns>An IAsyncResult that contains information about the status of the process.</returns>
        public IAsyncResult BeginProcessRequest( HttpContext context, AsyncCallback cb, object extraData )
        {
            try
            {
                string anID = context.Request.QueryString[0];

                if ( string.IsNullOrEmpty( anID ) )
                {
                    throw new Exception( "file id must be provided" );
                }

                int id = -1;
                Guid guid = new Guid();

                if ( !( int.TryParse( anID, out id ) || Guid.TryParse( anID, out guid ) ) )
                {
                    throw new Exception( "file id key must be a guid or an int" );
                }

                SqlConnection conn = new SqlConnection( string.Format( "{0};Asynchronous Processing=true;", ConfigurationManager.ConnectionStrings["RockContext"].ConnectionString ) );
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "BinaryFile_sp_getByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add( new SqlParameter( "@Id", id ) );
                cmd.Parameters.Add( new SqlParameter( "@Guid", guid ) );

                // store our Command to be later retrieved by EndProcessRequest
                context.Items.Add( "cmd", cmd );

                // start async DB read
                return cmd.BeginExecuteReader( cb, context,
                    CommandBehavior.SequentialAccess |  // doesn't load whole column into memory
                    CommandBehavior.SingleRow |         // performance improve since we only want one row
                    CommandBehavior.CloseConnection );  // close connection immediately after read
            }
            catch ( Exception ex )
            {
                // TODO: log this error
                context.Response.StatusCode = 500;
                context.Response.StatusDescription = ex.Message;
                context.Response.End();
                // to avoid compilation errors
                throw;
            }
        }

        /// <summary>
        /// Provides an end method for an asynchronous process. 
        /// </summary>
        /// <param name="result">An IAsyncResult that contains information about the status of the process.</param>
        public void EndProcessRequest( IAsyncResult result )
        {
            HttpContext context = (HttpContext)result.AsyncState;

            try
            {
                // restore the command from the context
                SqlCommand cmd = (SqlCommand)context.Items["cmd"];
                using ( SqlDataReader reader = cmd.EndExecuteReader( result ) )
                {
                    reader.Read();
                    context.Response.Clear();
                    context.Response.BinaryWrite( (byte[])reader["Data"] );
                    context.Response.AddHeader( "content-disposition", string.Format( "inline;filename={0}", reader["FileName"] ) );
                    context.Response.ContentType = (string)reader["MimeType"];
                    context.Response.Flush();
                    context.Response.End();
                    reader.Close();
                }
            }
            catch ( Exception ex )
            {
                // TODO: log this error
                context.Response.StatusCode = 500;
                context.Response.StatusDescription = ex.Message;
                context.Response.Flush();
                context.Response.End();
            }
        }

        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler" /> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext" /> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void ProcessRequest( HttpContext context )
        {
            throw new NotImplementedException( "The method or operation is not implemented. This is an asynchronous file handler." );
        }

        /// <summary>
        /// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler" /> instance.
        /// </summary>
        /// <returns>true if the <see cref="T:System.Web.IHttpHandler" /> instance is reusable; otherwise, false.</returns>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}