
using System.IO;

using System.Web;

namespace News24.Web.Extensions
{
    public static class HttpPostedFileBaseExtension
    {
        public static byte[] ToByteArray(this HttpPostedFileBase file)
        {
            var rdr = new BinaryReader(file.InputStream);
            var res = rdr.ReadBytes(file.ContentLength);
            return res;
        }
    }
}