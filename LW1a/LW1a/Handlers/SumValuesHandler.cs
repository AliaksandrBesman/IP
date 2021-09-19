using System;
using System.Web;

namespace LW1a.Handlers
{
    public class SumValuesHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var x = Convert.ToInt32(context.Request.Form.Get("X"));
            var y = Convert.ToInt32(context.Request.Form.Get("Y"));
            var sum = x + y;
            var res = context.Response;
            res.ContentType = "text/plain";
            res.Write(sum);
        }

        #endregion
    }
}
