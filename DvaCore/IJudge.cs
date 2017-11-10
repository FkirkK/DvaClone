using DvaCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DvaCore
{
    public interface IJudge
    {
        IResult JudgeResult(IResult result);
        IResult JudgeResults(List<IResult> result);
    }
}
