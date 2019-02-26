using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ECommerce.Classes
{
    public class FilesHelper
    {
        public static bool UpLoadPhoto(HttpPostedFileBase file, string folder, string name)
        {
            string path = string.Empty;
            //string pic = string.Empty;

            if (file == null || string.IsNullOrEmpty(folder) || string.IsNullOrEmpty(name))
            {
                return false;
            }
            try
            {
                if (file != null)
                {
                    //pic = Path.GetFileName(file.FileName);
                    path = Path.Combine(HttpContext.Current.Server.MapPath(folder), name);
                    file.SaveAs(path);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}