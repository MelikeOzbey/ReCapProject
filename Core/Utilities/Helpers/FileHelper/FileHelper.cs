using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper
    {
        public static string FilePath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var createUniqueFileName = Guid.NewGuid().ToString("N") + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + "_" + fileExtension;

            string path = Environment.CurrentDirectory + @"\Images";
            string result = $@"{path}\{createUniqueFileName}";
            return result;
        }

        public static string Add(IFormFile file)
        {
            var result = FilePath(file);
            try
            {
                var sourcePath = Path.GetTempFileName();
                if(file.Length>0)
                {
                    using (var stream=new FileStream(sourcePath,FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                File.Move(sourcePath, result);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

            return result;
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            var result = FilePath(file);
            try
            {
                if(sourcePath.Length>0)
                {
                    using (var stream=new FileStream(result,FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                File.Delete(sourcePath);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return result;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }
    }
}
