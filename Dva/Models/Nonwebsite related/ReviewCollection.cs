using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Dva.Models.Nonwebsite_related_logic
{
    public class ReviewCollection : ICollection<Review>
    {
        public List<Review> Reviews
        {
            get;
            set;
        }

        public int Count { get; }

        public bool IsReadOnly { get; }

        public void Add(Review item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(Review item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(Review[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(Review item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<Review> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}