using System;
using System.Collections.Generic;
using System.Text;
using DvaCore.Models;
using System.Linq;

namespace DvaCore
{
    public class MajorityJudge : IJudge
    {
        public IResult JudgeResult(IResult result)
        {
            return result;
        }

        public IResult JudgeResults(List<IResult> result)
        {
            var castedResult = result.Cast<ClassifierResult>().ToList(); //TODO: Remove IResult interface
            List<RatedDocument> judgedDocuments = new List<RatedDocument>();


            for (int i = 0; i < castedResult[0].RatedDocuments.Count; i++)
            {
                int truthfulCount = 0;
                int deceitfulCount = 0;
                for (int j = 0; j < castedResult.Count; j++)
                {
                    if (castedResult[j].RatedDocuments[i].OurClassifier)
                        truthfulCount++;
                    else
                        deceitfulCount++;
                }

                judgedDocuments.Add(new RatedDocument(castedResult[0].RatedDocuments[i].Name,
                                                      castedResult[0].RatedDocuments[i].LabeledClassifier,
                                                      (truthfulCount > deceitfulCount)));
            }

            return new ClassifierResult(judgedDocuments);
        }
    }
}
