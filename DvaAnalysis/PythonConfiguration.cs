using System;
using System.Collections.Generic;
using System.Text;

namespace DvaAnalysis
{
    public class PythonConfiguration : AnalysisConfiguration
    {
        public PythonConfiguration(Classification clas, BagOfWords bow)
        {
            Classification = clas;
            BagOfWords = bow;
        }

        public Classification Classification { get; }

        public BagOfWords BagOfWords { get; }
    }
}
