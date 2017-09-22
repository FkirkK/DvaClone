using System;
using System.Collections.Generic;
using System.Text;

namespace DvaCore.Models
{
    public class Review
    {
        public Review(string content, bool isTruthful, bool isPositive)
        {
            Content = content;
            IsTruthful = isTruthful;
            IsPositive = isPositive;
        }

        public bool IsTruthful { get; set; }
        public bool IsPositive { get; set; }
        public string Content { get; set; }
    }
}
