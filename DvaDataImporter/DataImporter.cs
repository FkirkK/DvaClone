using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DvaCore.Models;

namespace DvaDataImporter
{
    public class DataImporter
    {
        public DataImporter()
        {
            
        }

        // Imports all files from folder
        public Dictionary<string, string> ImportData(string path)
        {
            Dictionary<string, string> textFromFiles = new Dictionary<string, string>();

            var txtFiles = Directory.EnumerateFiles(path, "*.txt");

            foreach (string file in txtFiles)
            {
                var text = File.ReadAllText(file);
                textFromFiles.Add(Path.GetFileNameWithoutExtension(file), text);
            }

            return textFromFiles;
        }

        public List<Review> ImportReviews(string path)
        {
            List<Review> reviews = new List<Review>();
            reviews.AddRange(ImportReviewsHelper(path + "/negative_polarity/deceptive_from_MTurk/", false, false));
            reviews.AddRange(ImportReviewsHelper(path + "/negative_polarity/truthful_from_Web/", true, false));
            reviews.AddRange(ImportReviewsHelper(path + "/positive_polarity/deceptive_from_MTurk/", false, true));
            reviews.AddRange(ImportReviewsHelper(path + "/positive_polarity/truthful_from_TripAdvisor/", true, true));

            return reviews;
        }

        private List<Review> ImportReviewsHelper(string path, bool isTruthful, bool isPositive)
        {
            var directoryPaths = Directory.EnumerateDirectories(path);
            List<string> filePaths = new List<string>();
            List<Review> reviews = new List<Review>();

            foreach (var directory in directoryPaths)
            {
                filePaths.AddRange(Directory.EnumerateFiles(directory, "*.txt"));
            }

            foreach (var filePath in filePaths)
            {
                var text = File.ReadAllText(filePath);
                reviews.Add(new Review(text, isTruthful, isPositive));
            }

            return reviews;
        }
    }
}
