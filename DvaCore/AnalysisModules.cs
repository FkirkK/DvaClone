using System;
using System.Collections.Generic;
using System.Text;

namespace DvaCore
{
    public enum AnalysisModules
    {
        Bigram,
        BigramPlus,
        Unigram,
        Trigram,
        TrigramPlus,
        Default
    };

    public static class AnalysisModulesMethods
    {
        public static AnalysisModules ConvertToEnum(string input)
        {
            if (input == AnalysisModules.Bigram.ToString())
            {
                return AnalysisModules.Bigram;
            }
            else if (input == AnalysisModules.BigramPlus.ToString())
            {
                return AnalysisModules.BigramPlus;
            }
            else if (input == AnalysisModules.Unigram.ToString())
            {
                return AnalysisModules.Unigram;
            }
            else if (input == AnalysisModules.Trigram.ToString())
            {
                return AnalysisModules.Trigram;
            }
            else if (input == AnalysisModules.TrigramPlus.ToString())
            {
                return AnalysisModules.TrigramPlus;
            }
            else
            {
                return AnalysisModules.Default;
            }
        }
    }
}
