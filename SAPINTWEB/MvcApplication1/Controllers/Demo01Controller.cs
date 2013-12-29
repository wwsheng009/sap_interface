using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class Demo01Controller : ApiController
    {
        // GET api/demo01
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/demo01/5
        public string Get(int id)
        {
            id = id * 100;
            // var result = Request.Content.ReadAsStringAsync().Result;
            return id.ToString();
        }

        private string ReadStream(Stream s)
        {
            System.IO.Stream str;
            String strmContents;
            Int32 counter, strLen, strRead;
            // Create a Stream object.
            str = s;
            // Find number of bytes in stream.
            strLen = Convert.ToInt32(str.Length);
            // Create a byte array.
            byte[] strArr = new byte[strLen];
            // Read stream into byte array.
            strRead = str.Read(strArr, 0, strLen);

            // Convert byte array to a text string.
            strmContents = "";
            for (counter = 0; counter < strLen; counter++)
            {
                strmContents = strmContents + strArr[counter].ToString();
            }
            return strmContents;
        }
        // POST api/demo01
        public String Post([FromBody]string value)
        {
            var httpContext = (HttpContextWrapper)Request.Properties["MS_HttpContext"];
            var foo = httpContext.Request.Form["Foo"];
            var st = ReadStream(httpContext.Request.InputStream);
            //return this.Request.RequestUri.AbsoluteUri;
            var result = Request.Content.ReadAsStringAsync().Result;

            var dbconnection = ConfigFileTool.SAPGlobalSettings.GetDefaultDbConnection();
            //var dbconnection = "";
            SAPINTDB.netlib7 net = new SAPINTDB.netlib7(dbconnection);

            var forms = httpContext.Request.Form;

            for (int i = 0; i < forms.Count; i++)
            {
                var formvalue = forms.GetValues(i);
                var str = string.Empty;
                foreach (var item in formvalue)
                {
                    str = str + item; 
                }
                var formkey = forms.GetKey(i);
                var sql = string.Format("insert into sapdb.dbo.webapi([key],[value]) values('{0}','{1}');", formkey, str);
                net.ExecNonQuery(sql);
            }


            return result;
        }
        // POST api/demo01
        //public String Post(NameValueCollection formData)
        //{

        //    //return this.Request.RequestUri.AbsoluteUri;
        //    var result = Request.Content.ReadAsStringAsync().Result;
        //    return result;
        //}
        // PUT api/demo01/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/demo01/5
        public void Delete(int id)
        {
        }
    }
}
