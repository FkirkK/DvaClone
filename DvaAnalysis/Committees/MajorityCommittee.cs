using System;
using System.Collections.Generic;
using System.Text;
using DvaAnalysis.Models;
using System.Linq;

namespace DvaAnalysis.Committees
{
    public class MajorityCommittee : ICommittee
    {
        public IResult ClassifyResult(IResult result)
        {
            return result;
        }

        public IResult ClassifyResults(List<IResult> result)
        {
            var castedResult = result.Cast<ClassifierResult>().ToList(); //TODO: Remove IResult interface
            List<RatedDocument> ClassifiedDocuments = new List<RatedDocument>();


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

                ClassifiedDocuments.Add(new RatedDocument(castedResult[0].RatedDocuments[i].Name,
                    castedResult[0].RatedDocuments[i].LabeledClassifier,
                    (truthfulCount > deceitfulCount)));
            }

            return new ClassifierResult(ClassifiedDocuments);
        }
    }
}
