using System;
using System.Collections.Generic;
using System.Text;
using DvaCore.Models;

namespace DvaCore
{
    public class Judge : IJudge
    {
        public IResult judgeResult(IResult result)
        {
            return result;
        }

        public IResult judgeResults(List<IResult> result)
        {
            return result[0];
        }
    }
}
