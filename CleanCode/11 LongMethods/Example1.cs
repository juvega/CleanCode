using System;
using System.Web;

namespace FooFoo
{
    public partial class Download : System.Web.UI.Page
    {
        /*Los humanos solo puede memorizar unos 25 pasos a la vez
        Cohesion Principle
        > things that are related, should be together
        > things that are not related, should not be together.
        */

        private readonly DataTableToCsvMapper _dataTableToCsvMapper = new DataTableToCsvMapper();
        private readonly TableReader _tableReader = new TableReader();
        protected void Page_Load(object sender, EventArgs e)
        {            
            ClearResponse();
            SetCacheability();
            WriteContentToResponse(GetCsv());
        }

        private byte[] GetCsv()
        {
            System.IO.MemoryStream ms = _dataTableToCsvMapper.Map(_tableReader.GetDataTable());
            byte[] byteArray = ms.ToArray();
            ms.Flush();
            ms.Close();
            return byteArray;
        }

        private void WriteContentToResponse(byte[] byteArray)
        {
            Response.Charset = System.Text.UTF8Encoding.UTF8.WebName;
            Response.ContentEncoding = System.Text.UTF8Encoding.UTF8;
            Response.ContentType = "text/comma-separated-values";
            Response.AddHeader("Content-Disposition", "attachment; filename=FooFoo.csv");
            Response.AddHeader("Content-Length", byteArray.Length.ToString());
            Response.BinaryWrite(byteArray);
        }

        private void SetCacheability()
        {
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.CacheControl = "private";
            Response.AppendHeader("Pragma", "cache");
            Response.AppendHeader("Expires", "60");
        }

        private void ClearResponse()
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Cookies.Clear();
        }
    }
}