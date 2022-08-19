using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanTecTest.BL.Helpers;
using TitanTecTest.BL.Results;
using TitanTecTest.BL.Services.BaseServices;
using TitanTecTest.BL.Services.ServicesPool;
using TitanTecTest.DAL.Repositories.IRepositories;

namespace TitanTecTest.BL.Services.ImplementedServices
{
    public class FileService: BaseService
    {
        public enum ImageAllowedTypes
        {
            [Description("image/jpeg")]
            JPEG,
            [Description("image/gif")]
            GIF,
            [Description("image/png")]
            PNG

        }

        public FileService(IUnitOfWork unitOfWork, ServicePool otherServices, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, otherServices, httpContextAccessor)
        {
        }


        public async Task<UploadFileResult> UploadImageAsync(string imageKey, bool hasKey = true)
        {
            if (HttpContextAccessor.HttpContext.Request.Form.Files != null
                                        && (!hasKey || HttpContextAccessor.HttpContext.Request.Form.Files.Any(f => f.Name == imageKey)))
            {
                string fileName = "File_" + Guid.NewGuid() + "_" + DateTime.Now.Ticks;
                var file = HttpContextAccessor.HttpContext.Request.Form.Files.FirstOrDefault(f => !hasKey || f.Name == imageKey);
                string suffix = ValidateImage(file);
                if (suffix != null)
                {
                    string dirName =AppConst.ContentFolder;
                    var dir = AppConst.ContentFolder;
                    if (dir != null)
                        dirName = dir;
                    fileName = fileName + "." + suffix;
                    string path = dirName + "\\" + fileName;
                    if (file != null)
                    {
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        return new UploadFileResult()
                        {
                            FileName =  fileName,
                            IsUploadedSuccessFully = true
                        };
                    }
                    return new UploadFileResult()
                    {
                        IsUploadedSuccessFully = false
                    };
                }
            }
            throw new Exception("NoFileUploaded");
        }
        public long CalculteFileSize(string fileName)
        {
            long size = 0;
            fileName = AppConst.ContentFolder + fileName;
            FileInfo file = new FileInfo(fileName);
            if (file.Exists)
            {
                size= file.Length;
            }
            return size;
        }

        private string ValidateImage(IFormFile uploadedImg)
        {
            string[] words = null;
            if (uploadedImg != null)
            {
                
                if (!(uploadedImg.ContentType == EnumHelper.GetEnumDescription(ImageAllowedTypes.GIF) ||
                    uploadedImg.ContentType == EnumHelper.GetEnumDescription(ImageAllowedTypes.JPEG) ||
                    uploadedImg.ContentType == EnumHelper.GetEnumDescription(ImageAllowedTypes.PNG)))
                    throw new Exception("UploadFileTypeNotAllowed");

                if (uploadedImg.ContentType.Length > 0)
                    words = uploadedImg.ContentType.Split('/');
                return words[1];
            }
            else return null;
        }
    }
}
