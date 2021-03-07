using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.Result.Concrete;
using ReCapProject.Core.Utilities.Result.Abstract;

namespace ReCapProject.Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcePath = Path.GetTempFileName(); // geçici bir dosya oluşturulur
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            var result = newPath(file);
            File.Move(sourcePath, result);
            return result;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);

            }
            return new SuccessResult();
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Delete(sourcePath);
            return result;
        }

        public static string newPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            string path = Environment.CurrentDirectory + @"c:\\Images\carImages";
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Year +
                          fileExtension;
            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}
