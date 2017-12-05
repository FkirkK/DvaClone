using System;
using System.Collections.Generic;
using System.Text;

namespace DvaAnalysis.Models
{
    public class Review
    {
        /// <summary>
        /// Constructor for the Review class
        /// </summary>
        /// <param name="content">Content of the review</param>
        /// <param name="title">Title of the review</param>
        /// <param name="isTruthful">Whether the review is labeled as truthful or deceptive</param>
        /// <param name="isPositive">Whether or not the review is a positive or negative</param>
        public Review(string content, string title, bool isTruthful, bool isPositive)
        {
            Content = content;
            Title = title;
            IsTruthful = isTruthful;
            IsPositive = isPositive;
        }
        /// <summary>
        /// Whether the review is labeled as truthful or deceptive
        /// </summary>
        public bool IsTruthful { get; set; }
        /// <summary>
        /// Whether or not the review is a positive or negative
        /// </summary>
        public bool IsPositive { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return Content;
        }
    }
}
