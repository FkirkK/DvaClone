using System;
using System.Collections.Generic;
using System.Text;

namespace DvaAnalysis
{
    public class PythonConfiguration : AnalysisConfiguration
    {
        public PythonConfiguration(Classification clas, BagOfWords bow) : base(ConfigurationType.PythonRunner)
        {
            Classification = clas;
            BagOfWords = bow;
        }

        internal object[] GetArguments()
        {
            object[] arguments = new object[2];

            arguments[0] = Classification.ToString();
            arguments[1] = BagOfWords.ToString();

            return arguments;
        }

        public Classification Classification { get; }

        public BagOfWords BagOfWords { get; }
    }
}
