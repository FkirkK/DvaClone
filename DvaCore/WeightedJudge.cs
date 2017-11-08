using System;
using System.Collections.Generic;
using System.Linq;
using DvaCore.Models;

namespace DvaCore
{
    public class WeightedJudge : IJudge
    {
        public WeightedJudge(List<double> weights)
        {
            _weights = weights;
        }

        private List<double> _weights;

        public IResult JudgeResult(IResult result)
        {
            return result;
        }

        public IResult JudgeResults(List<IResult> result)
        {
            if (result.Count != _weights.Count)
                throw new ArgumentException("WeigtedJudge arity mismatch between weights provided and number of results.");

            var castedResult = result.Cast<ClassifierResult>().ToList(); //TODO: Remove IResult interface
            List<RatedDocument> judgedDocuments = new List<RatedDocument>();

            for (int i = 0; i < castedResult[0].RatedDocuments.Count; i++)
            {
                double truthfulScore = 0;
                double deceitfulScore = 0;
                for (int j = 0; j < castedResult.Count; j++)
                {
                    if (castedResult[j].RatedDocuments[i].OurClassifier)
                        truthfulScore += (1.0 * _weights[j]);
                    else
                        deceitfulScore += (1.0 * _weights[j]);
                }

                judgedDocuments.Add(new RatedDocument(castedResult[0].RatedDocuments[i].Name,
                    castedResult[0].RatedDocuments[i].LabeledClassifier,
                    (truthfulScore > deceitfulScore)));
            }

            return new ClassifierResult(judgedDocuments);
        }
    }
}