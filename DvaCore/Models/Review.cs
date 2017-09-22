using System;
using System.Collections.Generic;
using System.Text;

namespace DvaCore.Models
{
    public class Review
    {
        public Review(string content, string title, bool isTruthful, bool isPositive)
        {
            Content = content;
            Title = title;
            IsTruthful = isTruthful;
            IsPositive = isPositive;
        }

        public bool IsTruthful { get; set; }
        public bool IsPositive { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return Content;
        }
    }
}
