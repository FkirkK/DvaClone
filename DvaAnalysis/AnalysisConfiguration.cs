using System;
using System.Collections.Generic;
using System.Text;

namespace DvaAnalysis
{
    public class AnalysisConfiguration
    {
        public AnalysisConfiguration(ConfigurationType configType)
        {
            ConfigurationType = configType;
        }

        public ConfigurationType ConfigurationType { get; }
    }
}
