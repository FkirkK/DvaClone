using System;
using System.Collections.Generic;
using System.Text;
using DvaCore.Models;

namespace DvaCore
{
    public class Judge : IJudge
    {
        public IResult judgeResults(IResult result)
        {
            return result;
        }
    }
}
