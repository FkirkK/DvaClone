using System;
using System.Collections.Generic;
using System.Text;
using DvaAnalysis.Models;

namespace DvaAnalysis.Committees
{
    public class DummyCommittee : ICommittee
    {
        public IResult ClassifyResult(IResult result)
        {
            return result;
        }

        public IResult ClassifyResults(List<IResult> result)
        {
            return result[0];
        }
    }
}
