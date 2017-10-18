using DvaCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DvaCore
{
    public interface IJudge
    {
        IResult judgeResults(IResult result);
    }
}
