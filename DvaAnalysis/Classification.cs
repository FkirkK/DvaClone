using System;
using System.Collections.Generic;
using System.Text;

namespace DvaAnalysis
{
    public enum Classification
    {
        SVCLinear,
        SVCPolynomial,
        SVCRbf,
        SVCSigmoid,
        LinearSVC,
        DecisionTree,
        NaiveBayes,
        MultiLayerPerceptron,
        NearestNeighbors,
        AdaBoost,
        Bagging
    }

    public static class ClassificationExtension
    {
        public static string Prettify(this Classification c)
        {
            switch (c)
            {
                case Classification.SVCLinear: return "SVC linear kernel";
                case Classification.SVCPolynomial: return "SVC polynomial kernel";
                case Classification.SVCRbf: return "SVC rbf kernel";
                case Classification.SVCSigmoid: return "SVC sigmoid kernel";
                case Classification.LinearSVC: return "Linear SVC";
                case Classification.DecisionTree: return "Decision tree";
                case Classification.NaiveBayes: return "Naive bayes";
                case Classification.MultiLayerPerceptron: return "Multilayer perceptron";
                case Classification.NearestNeighbors: return "Nearest neighbors";
                case Classification.AdaBoost: return "AdaBoost with decision trees";
                case Classification.Bagging: return "Bagging with decision trees";
                default: return "No pretty string for classifier";
            }
        }

        public static Classification Deprettify(string input)
        {
            switch (input)
            {
                case "SVC linear kernel": return Classification.SVCLinear;
                case "SVC polynomial kernel": return Classification.SVCPolynomial;
                case "SVC rbf kernel": return Classification.SVCRbf;
                case "SVC sigmoid kernel": return Classification.SVCSigmoid;
                case "Linear SVC": return Classification.LinearSVC;
                case "Decision tree": return Classification.DecisionTree;
                case "Naive bayes": return Classification.NaiveBayes;
                case "Multilayer perceptron": return Classification.MultiLayerPerceptron;
                case "Nearest neighbors": return Classification.NearestNeighbors;
                case "AdaBoost with decision trees": return Classification.AdaBoost;
                case "Bagging with decision trees": return Classification.Bagging;
                default: throw new ArgumentException(input + " is not a valid prettified Classification string.");
            }
        }
    }
}
