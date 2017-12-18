using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using DvaAnalysis;
using DvaAnalysis.Committees;
using DvaAnalysis.Models;
using System.Linq;

namespace DvaResultGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            AnalysisRunner ar = new AnalysisRunner();
            MajorityCommittee mc = new MajorityCommittee();
            Stopwatch sw = new Stopwatch();

            foreach (Classification classifier in Enum.GetValues(typeof(Classification)))
            {
                List<Tuple<IResult, TimeSpan>> results = new List<Tuple<IResult, TimeSpan>>();
                foreach (FeatureSet feature in Enum.GetValues(typeof(FeatureSet)))
                {
                    Console.WriteLine("Doing: " + classifier.ToString() + "-" + feature.ToString());
                    PythonConfiguration config = new PythonConfiguration(classifier, feature);
                    sw.Restart();
                    var res = ar.RunAnalysis(config, mc);

                    if (res == null)
                        res = new ErrorResult("Error result was null");

                    results.Add(new Tuple<IResult, TimeSpan>(res ,sw.Elapsed));
                }

                List<IResult> readyForCommittee = new List<IResult>();
                for (int i = 0; i < 5; i++)
                {
                    readyForCommittee.Add(results[i].Item1);
                }
                results.Add(new Tuple<IResult, TimeSpan>(mc.ClassifyResults(readyForCommittee), new TimeSpan()));

                PrintLatexResults(results, classifier.ToString());
            }
        }

        static void PrintLatexResults(List<Tuple<IResult, TimeSpan>> res, string classifier)
        {
            using (StreamWriter file = new StreamWriter(@"/home/bs/Desktop/Results.txt", true))
            {
                file.WriteLine("\\subsection *{" + classifier + "}");
                file.WriteLine("\\begin{table}[H]");
                file.WriteLine("\\centering");
                file.WriteLine("\\begin{tabular}{| l | r | r | r | r | r | r |}\\hline");
                file.WriteLine("Dimensionalizer & Accuracy & T.Precision & T.Recall & D.Precision & D.Recall & Runtime \\\\ \\hline");
                file.WriteLine("Unigram & " + PrintAlgorithmLine(res[0].Item1, res[0].Item2));
                file.WriteLine("Bigram & " + PrintAlgorithmLine(res[1].Item1, res[1].Item2));
                file.WriteLine("Trigram & " + PrintAlgorithmLine(res[3].Item1, res[3].Item2));
                file.WriteLine("Bigram+ & " + PrintAlgorithmLine(res[2].Item1, res[2].Item2));
                file.WriteLine("Trigram+ & " + PrintAlgorithmLine(res[4].Item1, res[4].Item2));
                file.WriteLine("Doc2Vec & " + PrintAlgorithmLine(res[5].Item1, res[5].Item2));
                file.WriteLine("Combined & " + PrintAlgorithmLine(res[6].Item1, res[6].Item2));
                file.WriteLine("\\end{tabular}");
                file.WriteLine("\\caption{"+ classifier +"}");
                file.WriteLine("\\label{test-result-AdaBoost}");
                file.WriteLine("\\end{table}");
            }
        }

        static string PrintAlgorithmLine(IResult result, TimeSpan time)
        {
            if (result is ErrorResult res2)
                return res2.Message + " & & & & & \\\\ \\hline";

            var res = (ClassifierResult) result;

            return Math.Round(res.Accuracy * 100, 1) + "\\% & " + Math.Round(res.TruthfulPrecision * 100, 1) + "\\% & " + Math.Round(res.TruthfulRecall * 100, 1) + "\\% & " +
                   Math.Round(res.DeceitfulPrecision * 100, 1) + "\\% & " + Math.Round(res.DeceitfulRecall * 100, 1) + "\\% & " + time.Minutes + " : " + time.Seconds + " \\\\ \\hline";
        }
    }
}
