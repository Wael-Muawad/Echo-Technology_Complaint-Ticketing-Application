using Domain.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FileService : IFileService
    {
        public string _fielsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files");

        public async Task<string> SaveFile(IFormFile file)
        {
            var path = Path.Combine(Guid.NewGuid().ToString(), Path.GetExtension(file.FileName));

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return file.Name;
        }
    }
}
