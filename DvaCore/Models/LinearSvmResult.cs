using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace DvaCore.Models
{
    public class LinearSvmResult : IResult
    {
        /// <summary>
        /// Constructor for LinearSvmResult
        /// </summary>
        /// <param name="inputToParse">A string formatted correctly to set all of the classes properties</param>
        public LinearSvmResult(string inputToParse)
        {
            Parse(inputToParse);
        }
        
        public double OverallPrecision { get; private set; }
        public int OverallBestFold { get; private set; }
        public int OverallWorstFold { get; private set; }
        public double FalsePositives { get; private set; }
        public int FalsePositivesBestFold { get; private set; }
        public int FalsePositivesWorstFold { get; private set; }
        public double FalseNegatives { get; private set; }
        public int FalseNegativesBestFold { get; private set; }
        public int FalseNegativesWorstFold { get; private set; }
        public IList<RatedDocument> RatedDocuments { get; private set; }

        public override bool Equals(object obj)
        {
            var svmResult = (LinearSvmResult) obj;
            var isSame = true;

            isSame &= OverallPrecision.Equals(svmResult.OverallPrecision);
            isSame &= OverallBestFold.Equals(svmResult.OverallBestFold);
            isSame &= OverallWorstFold.Equals(svmResult.OverallWorstFold);
            isSame &= FalsePositives.Equals(svmResult.FalsePositives);
            isSame &= FalsePositivesBestFold.Equals(svmResult.FalsePositivesBestFold);
            isSame &= FalsePositivesWorstFold.Equals(svmResult.FalsePositivesWorstFold);
            isSame &= FalseNegatives.Equals(svmResult.FalseNegatives);
            isSame &= FalseNegativesBestFold.Equals(svmResult.FalseNegativesBestFold);
            isSame &= FalseNegativesWorstFold.Equals(svmResult.FalseNegativesWorstFold);
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
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            var splitInput = input.Split(',');

            if (splitInput.Length >= 9 && splitInput.Length % 3 == 0)
            {
                OverallPrecision = double.Parse(splitInput[0]);
                OverallBestFold = int.Parse(splitInput[1]);
                OverallWorstFold = int.Parse(splitInput[2]);
                FalsePositives = double.Parse(splitInput[3]);
                FalsePositivesBestFold = int.Parse(splitInput[4]);
                FalsePositivesWorstFold = int.Parse(splitInput[5]);
                FalseNegatives = double.Parse(splitInput[6]);
                FalseNegativesBestFold = int.Parse(splitInput[7]);
                FalseNegativesWorstFold = int.Parse(splitInput[8]);

                var docList = new List<RatedDocument>();
                for (int i = 9; i < splitInput.Length; i += 3)
                {
                    string name = splitInput[i].Trim();
                    bool deceptive = splitInput[i + 1].Trim() == "1";
                    bool rating = splitInput[i + 2].Trim() == "1";

                    docList.Add(new RatedDocument(name, deceptive, rating));
                }

                RatedDocuments = docList;
            }
            else
            {
                throw new ArgumentException("LinearSvmResult.Parse: " + input + " is invalid.");
            }
        }
    }
}