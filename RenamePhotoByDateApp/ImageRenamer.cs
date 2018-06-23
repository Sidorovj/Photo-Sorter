using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RenamePhotoByDateApp
{
    class ImageRenamer
    {
        public int Progress { get; private set; } = 0;
        public int FilesCount { get; private set; } = 0;
        public string FolderPath { get; private set; }

        private const string SortedFolderName = "AppSorted";

        public ImageRenamer(string folderPath)
        {
            FolderPath = folderPath;
        }
        
        public void RenameInFolder(bool ascendingSort, bool saveOldFiles)
        {
            var photos = GetFilesInFolder();
            FilesCount = photos.Count;
            photos = Sort(photos, ascendingSort);
            SaveNewFiles(photos, saveOldFiles);
        }

        private void SaveNewFiles(List<Photo> photos, bool saveOldFiles)
        {
            string newDir = FolderPath + "/" + SortedFolderName;
            int dirIterator = 1;
            if (!Directory.Exists(newDir))
                Directory.CreateDirectory(newDir);
            else
            {
                while (Directory.Exists($"{newDir}{dirIterator}"))
                    dirIterator++;
                newDir += dirIterator.ToString();
                Directory.CreateDirectory(newDir);
            }
            int counter = 1;
            string format = new string('0', photos.Count.ToString().Length);
            foreach (var photo in photos)
            {
                string fileName = photo.Path.Substring(photo.Path.LastIndexOfAny(new char[] { '/', '\\' })+1);
                string newFilePath = $"{newDir}/{counter.ToString(format)}__{fileName}";
                if (!File.Exists(newFilePath))
                {
                    byte[] bytes = File.ReadAllBytes(photo.Path);
                    var fs = File.Create(newFilePath);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
                Progress = counter;
                counter++;
                //if (!saveOldFiles)
                //    File.Delete(photo.Path);
            }
        }

        private List<Photo> GetFilesInFolder(string path = null)
        {
            List<Photo> photos = new List<Photo>();
            foreach (var dir in Directory.EnumerateDirectories(path??FolderPath))
            {
                if (!dir.Substring(dir.LastIndexOfAny(new char[] { '/', '\\' }) + 1).StartsWith(SortedFolderName))
                    photos.AddRange(GetFilesInFolder(dir));
            }
            foreach (var file in Directory.EnumerateFiles(path??FolderPath))
            {
                photos.Add(new Photo(file, GetCreatedOnOfFile(file)));
            }
            return photos;
        }

        private List<Photo> Sort(List<Photo> photos, bool ascendingSort)
        {
            QuickSorter<Photo> qs = new QuickSorter<Photo>(ascendingSort);
            return qs.Sort(photos);
        }

        private DateTime GetCreatedOnOfFile(string path)
        {
            ImagePropertyExtracter extracter = new ImagePropertyExtracter();
            return extracter.GetDateTakenFromImage(path);
        }

        private class ImagePropertyExtracter
        {
            private Regex _r = new Regex(":");
            private const int CreatedOnPropertyId = 36867;
            public DateTime GetDateTakenFromImage(string path)
            {
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        using (Image photo = Image.FromStream(fs, false, false))
                        {
                            if (photo.PropertyIdList.Contains(CreatedOnPropertyId))
                            {
                                PropertyItem propItem = photo.GetPropertyItem(CreatedOnPropertyId);
                                string dateTaken = _r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
                                return DateTime.Parse(dateTaken);
                            }
                        }
                    }
                }
                catch { }

                DateTime creation = File.GetCreationTime(path);
                DateTime modification = File.GetLastWriteTime(path);
                return modification < creation ? modification : creation;
            }
        }

    }
}