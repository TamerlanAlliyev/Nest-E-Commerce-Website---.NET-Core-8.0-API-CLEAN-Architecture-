﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Infrastructure.Extensions;

public static class FileExtensions
{
   public static async Task<string> SaveFileAsync(this IFormFile file, string root, string folder)
    {
        if (!Directory.Exists(Path.Combine(root, folder)))
        {
            Directory.CreateDirectory(Path.Combine(root, folder));
        }
        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        string path = Path.Combine(root, folder, uniqueFileName);


        using FileStream fs = new FileStream(path, FileMode.Create);

        await file.CopyToAsync(fs);

        return uniqueFileName;
    }


    public static bool CheckFileType(this IFormFile file, string fileType)
    {
        if (file.ContentType.Contains(fileType))
        {
            return true;
        }
        return false;
    }

    public static bool CheckFileSize(this IFormFile file, int fileSize)
    {
        if (file.Length > fileSize * 1024 * 1024)
        {
            return false;
        }
        return true;
    }

    public static void DeleteFile(string root, string folderName, string fileName)
    {
        string path = Path.Combine(root, folderName, fileName);
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
