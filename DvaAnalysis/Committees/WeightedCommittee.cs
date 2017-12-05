using System;
using System.Collections.Generic;
using System.Linq;
using DvaAnalysis.Models;

namespace DvaAnalysis.Committees
{
    public class WeightedCommittee : ICommittee
    {
        public WeightedCommittee(List<double> weights)
        {
            _weights = weights;
        }

        private List<double> _weights;

        public IResult ClassifyResult(IResult result)
        {
            return result;
        }

        public IResult ClassifyResults(List<IResult> result)
        {
            if (result.Count != _weights.Count)
                throw new ArgumentException("WeigtedCommittee arity mismatch between weights provided and number of results.");

            var castedResult = result.Cast<ClassifierResult>().ToList(); //TODO: Remove IResult interface
            List<RatedDocument> classifiedDocuments = new List<RatedDocument>();

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

                classifiedDocuments.Add(new RatedDocument(castedResult[0].RatedDocuments[i].Name,
                    castedResult[0].RatedDocuments[i].LabeledClassifier,
                    (truthfulScore > deceitfulScore)));
            }

            return new ClassifierResult(classifiedDocuments);
        }
    }
}