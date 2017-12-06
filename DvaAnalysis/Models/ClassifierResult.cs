using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace DvaAnalysis.Models
{
    public class ClassifierResult : IResult
    {
        /// <summary>
        /// Constructor for ClassifierResult
        /// </summary>
        /// <param name="inputToParse">A string formatted correctly to set all of the classes properties</param>
        public ClassifierResult(string inputToParse)
        {
            Parse(inputToParse);
        }

        public ClassifierResult(List<RatedDocument> docList)
        {
            int trueTruthful = 0;
            int falseTruthful = 0;
            int trueDeceitul = 0;
            int falseDeceitful = 0;

            foreach (RatedDocument doc in docList)
            {
                if (doc.LabeledClassifier && doc.OurClassifier)
                    trueTruthful++;
                else if (!doc.LabeledClassifier && doc.OurClassifier)
                    falseTruthful++;
                else if (!doc.LabeledClassifier && !doc.OurClassifier)
                    trueDeceitul++;
                else if (doc.LabeledClassifier && !doc.OurClassifier)
                    falseDeceitful++;
            }

            TrueTruthful = trueTruthful;
            FalseTruthful = falseTruthful;
            TrueDeceitful = trueDeceitul;
            FalseDeceitful = falseDeceitful;
            RatedDocuments = docList;
        }

        public double Accuracy
        {
            get
            {
                return (double)(TrueTruthful + TrueDeceitful) / (double)(TrueTruthful + FalseTruthful + TrueDeceitful + FalseDeceitful);
            }
        }
        public double TruthfulPrecision
        {
            get
            {
                return (double)TrueTruthful / (double)(TrueTruthful + FalseTruthful);
            }
        }
        public double TruthfulRecall
        {
            get
            {
                return (double)TrueTruthful / (double)(TrueTruthful + FalseDeceitful);
            }
        }
        public double DeceitfulPrecision
        {
            get
            {
                return (double)TrueDeceitful / (double)(TrueDeceitful + FalseDeceitful);
            }
        }
        public double DeceitfulRecall
        {
            get
            {
                return (double)TrueDeceitful / (double)(TrueDeceitful + FalseTruthful);
            }
        }
        public int TrueTruthful { get; private set; }
        public int FalseTruthful { get; private set; }
        public int TrueDeceitful { get; private set; }
        public int FalseDeceitful { get; private set; }
        public IList<RatedDocument> RatedDocuments { get; private set; }

        public override bool Equals(object obj)
        {
            var svmResult = obj as ClassifierResult;
            if (svmResult == null)
                return false;

            var isSame = true;

            isSame &= Accuracy.Equals(svmResult.Accuracy);
            isSame &= TrueTruthful.Equals(svmResult.TrueTruthful);
            isSame &= FalseTruthful.Equals(svmResult.FalseTruthful);
            isSame &= TrueDeceitful.Equals(svmResult.TrueDeceitful);
            isSame &= FalseDeceitful.Equals(svmResult.FalseDeceitful);
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

            if (splitInput.Length >= 4 && splitInput.Length % 3 == 1)
            {
                TrueTruthful = int.Parse(splitInput[0]);
                FalseTruthful = int.Parse(splitInput[1]);
                TrueDeceitful = int.Parse(splitInput[2]);
                FalseDeceitful = int.Parse(splitInput[3]);

                var docList = new List<RatedDocument>();
                for (int i = 4; i < splitInput.Length; i += 3)
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
                throw new ArgumentException("ClassifierResult.Parse: " + input + " is invalid.");
            }
        }
    }
}