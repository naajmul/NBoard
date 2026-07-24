using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NBoard.Models;
using Newtonsoft.Json;

namespace NBoard.Services
{
    public class DocumentManager
    {
        private static readonly string DocumentsFolder = 
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NBoard");

        static DocumentManager()
        {
            if (!Directory.Exists(DocumentsFolder))
                Directory.CreateDirectory(DocumentsFolder);
        }

        public static void SaveDocument(Document document)
        {
            try
            {
                string filePath = Path.Combine(DocumentsFolder, $"{document.Id}.wbd");
                document.FilePath = filePath;
                document.Modified = DateTime.Now;

                string json = JsonConvert.SerializeObject(document, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving document: {ex.Message}");
            }
        }

        public static Document LoadDocument(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Document>(json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading document: {ex.Message}");
            }
        }

        public static List<Document> GetRecentDocuments(int count = 10)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(DocumentsFolder);
                var files = di.GetFiles("*.wbd")
                    .OrderByDescending(f => f.LastWriteTime)
                    .Take(count)
                    .ToList();

                List<Document> documents = new List<Document>();
                foreach (var file in files)
                {
                    try
                    {
                        var doc = LoadDocument(file.FullName);
                        documents.Add(doc);
                    }
                    catch { }
                }

                return documents;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting recent documents: {ex.Message}");
            }
        }

        public static void DeleteDocument(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting document: {ex.Message}");
            }
        }

        public static string GetDocumentsFolder()
        {
            return DocumentsFolder;
        }
    }
}