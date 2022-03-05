using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sidekick.NET
{
    public static class FileOperations
    {
        public static string SavePhotos(List<IFormFile> photos, string directoryPath)
        {
            CreateDirectoryIfNotExist(directoryPath);

            StringBuilder photoURLBuilder = new();

            List<string> uploadPaths = new();

            foreach (IFormFile photo in photos)
            {
                string fileName = new StringBuilder()
                    .Append(Path.GetFileNameWithoutExtension(photo.FileName))
                    .Append('-')
                    .Append(Guid.NewGuid().ToString().Replace("-", string.Empty))
                    .Append(Path.GetExtension(photo.FileName)).ToString();

                uploadPaths.Add(Path.Combine($"{directoryPath}", fileName));

                photoURLBuilder.Append($"{fileName}|");
            }

            photoURLBuilder.Remove(photoURLBuilder.Length - 1, 1);
            string combinedFileNames = photoURLBuilder.ToString();

            for (int i = 0; i < photos.Count; i++)
            {
                string path = uploadPaths[i];

                using FileStream fileStream = new(path, FileMode.CreateNew);
                photos[i].CopyTo(fileStream);
            }

            return combinedFileNames;
        }

        public static string SavePhoto(IFormFile photo, string directoryPath)
        {
            CreateDirectoryIfNotExist(directoryPath);

            string fileName = new StringBuilder()
                .Append(Path.GetFileNameWithoutExtension(photo.FileName))
                .Append('-')
                .Append(Guid.NewGuid().ToString().Replace("-", string.Empty))
                .Append(Path.GetExtension(photo.FileName)).ToString();


            string fullPath = Path.Combine($"{directoryPath}", fileName);

            using FileStream fileStream = new(fullPath, FileMode.CreateNew);
            photo.CopyTo(fileStream);

            return fileName.ToString();
        }

        public static void RemoveOldPhotos(string photoURL, string directoryPath)
        {
            if (string.IsNullOrEmpty(photoURL))
                return;

            IEnumerable<string> urls = photoURL.Split("|");

            foreach (string url in urls)
            {
                string fullPath = Path.Combine(directoryPath, url);

                if (File.Exists(fullPath))
                    File.Delete(fullPath);
            }
        }

        private static void CreateDirectoryIfNotExist(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }
    }
}