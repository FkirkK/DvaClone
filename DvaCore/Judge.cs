using System;
using System.Collections.Generic;
using System.Text;
using DvaCore.Models;

namespace DvaCore
{
    public class Judge : IJudge
    {
        public IResult JudgeResult(IResult result)
        {
            return result;
        }

        public IResult JudgeResults(List<IResult> result)
        {
            return result[0];
        }
    }
}
