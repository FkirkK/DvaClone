using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using DvaAnalysis;
using DvaAnalysis.Committees;
using DvaAnalysis.Models;

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
                    PythonConfiguration config = new PythonConfiguration(classifier, feature);
                    sw.Restart();

                    results.Add(new Tuple<IResult, TimeSpan>(ar.RunAnalysis(config, mc),sw.Elapsed));
                }
                PrintLatexResults(results, sw.Elapsed, classifier.Prettify());
            }
        }

        static void PrintLatexResults(List<Tuple<IResult, TimeSpan>> res, TimeSpan time, string classifier)
        {
            using (StreamWriter file = new StreamWriter(@"C:\Users\marcb\Documents\GitHub\Dva\Results.txt", true))
            {
                file.WriteLine("\\subsection *{" + classifier + "}");
                file.WriteLine("\\begin{table}[H]");
                file.WriteLine("\\centering");
                file.WriteLine("\\begin{tabular}{| l | r | r | r | r | r | r |}\\hline");
                file.WriteLine("Dim. & Accuracy & T.Precision & T.Recall & D.Precision & D.Recall & Runtime \\\\ \\hline");
                file.WriteLine("Unigram & " + PrintAlgorithmLine((ClassifierResult)res[0].Item1, res[0].Item2));
                file.WriteLine("Bigram & " + PrintAlgorithmLine((ClassifierResult)res[1].Item1, res[1].Item2));
                file.WriteLine("Trigram & " + PrintAlgorithmLine((ClassifierResult)res[2].Item1, res[2].Item2));
                file.WriteLine("Bigram+ & " + PrintAlgorithmLine((ClassifierResult)res[3].Item1, res[3].Item2));
                file.WriteLine("Trigram+ & " + PrintAlgorithmLine((ClassifierResult)res[4].Item1, res[4].Item2));
                file.WriteLine("Doc2Vec & " + PrintAlgorithmLine((ClassifierResult)res[5].Item1, res[5].Item2));
                file.WriteLine("\\end{tabular}");
                file.WriteLine("\\caption{"+ classifier +" results}");
                file.WriteLine("\\label{test-result-AdaBoost}");
                file.WriteLine("\\end{table}");
            }
        }

        static string PrintAlgorithmLine(ClassifierResult res, TimeSpan time)
        {
            return Math.Round(res.Accuracy * 100, 1) + "\\% & " + Math.Round(res.TruthfulPrecision * 100, 1) + "\\% & " + Math.Round(res.TruthfulRecall * 100, 1) + "\\% & " +
                   Math.Round(res.DeceitfulPrecision * 100, 1) + "\\% & " + Math.Round(res.DeceitfulRecall * 100, 1) + "\\% & " + time.Minutes + " : " + time.Seconds + " \\\\ \\hline";
        }
    }
}
