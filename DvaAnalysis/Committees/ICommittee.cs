using DvaAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DvaAnalysis.Committees
{
    public interface ICommittee
    {
        IResult ClassifyResult(IResult result);
        IResult ClassifyResults(List<IResult> result);
    }
}
