using System;
using System.Collections.Generic;
using System.Linq;

namespace DvaCore.Models
{
    public class LinearSvmResult
    {
        public LinearSvmResult(string inputToParse)
        {
            Parse(inputToParse);
        }

        public double OverallPrecision { get; private set; }
        public double OverallBest { get; private set; }
        public double OverallWorst { get; private set; }
        public double FalsePositives { get; private set; }
        public double FalsePositivesBest { get; private set; }
        public double FalsePositivesWorst { get; private set; }
        public double FalseNegatives { get; private set; }
        public double FalseNegativesBest { get; private set; }
        public double FalseNegativesWorst { get; private set; }
        public IList<RatedDocument> RatedDocuments { get; private set; }

        public override bool Equals(object obj)
        {
            var svmResult = (LinearSvmResult) obj;
            var isSame = true;

            isSame &= OverallPrecision.Equals(svmResult.OverallPrecision);
            isSame &= OverallBest.Equals(svmResult.OverallBest);
            isSame &= OverallWorst.Equals(svmResult.OverallWorst);
            isSame &= FalsePositives.Equals(svmResult.FalsePositives);
            isSame &= FalsePositivesBest.Equals(svmResult.FalsePositivesBest);
            isSame &= FalsePositivesWorst.Equals(svmResult.FalsePositivesWorst);
            isSame &= FalseNegatives.Equals(svmResult.FalseNegatives);
            isSame &= FalseNegativesBest.Equals(svmResult.FalseNegativesBest);
            isSame &= FalseNegativesWorst.Equals(svmResult.FalseNegativesWorst);
            isSame &= RatedDocuments.Count == svmResult.RatedDocuments.Count;
            
            if (isSame)
                for (int i = 0; i < RatedDocuments.Count; i++)
                {
                    isSame &= RatedDocuments[i].Equals(svmResult.RatedDocuments[i]);
                }
            
            return isSame;
        }

        private void Parse(string input)
        {
            var splitInput = input.Split(',');

            OverallPrecision = double.Parse(splitInput[0]);
            OverallBest = double.Parse(splitInput[1]);
            OverallWorst = double.Parse(splitInput[2]);
            FalsePositives = double.Parse(splitInput[3]);
            FalsePositivesBest = double.Parse(splitInput[4]);
            FalsePositivesWorst = double.Parse(splitInput[5]);
            FalseNegatives = double.Parse(splitInput[6]);
            FalseNegativesBest = double.Parse(splitInput[7]);
            FalseNegativesWorst = double.Parse(splitInput[8]);

            var docList = new List<RatedDocument>();
            for (int i = 9; i < splitInput.Length; i+=3)
            {
                string name = splitInput[i].Trim();
                bool deceptive = splitInput[i + 1].Trim() == "1";
                bool rating = splitInput[i + 2].Trim() == "1";
                
                docList.Add(new RatedDocument(name, deceptive, rating));
            }

            RatedDocuments = docList;

        }
    }
}