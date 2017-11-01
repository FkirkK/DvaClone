using System;
using System.Collections.Generic;
using System.Text;

namespace DvaAnalysis
{
    public class PythonConfiguration : AnalysisConfiguration
    {
        public PythonConfiguration(Classification classification, FeatureSet featureSet) : base(ConfigurationType.PythonRunner)
        {
            Classification = classification;
            FeatureSet = featureSet;
        }

        internal object[] GetArguments()
        {
            object[] arguments = new object[2];

            arguments[0] = Classification.ToString();
            arguments[1] = FeatureSet.ToString();

            return arguments;
        }

        public Classification Classification { get; }

        public FeatureSet FeatureSet { get; }
    }
}
