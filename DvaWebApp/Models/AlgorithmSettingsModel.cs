using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using DvaAnalysis;

namespace DvaWebApp.Models
{
    public class AlgorithmSettingsModel
    {
        public List<SingleAlgorithmSettings> AlgorithmSettings { get; set; }
    }
    public class SingleAlgorithmSettings
    {
        public SingleAlgorithmSettings()
        {
            FeatureSetList = new SelectList(Enum.GetNames(typeof(FeatureSet)));
            ClassificationList = new SelectList(Enum.GetNames(typeof(Classification)));
        }

        public SelectList FeatureSetList { get; set; }
        public SelectList ClassificationList { get; set; }
        public string SelectedFeatureSet { get; set; }
        public string SelectedClassification { get; set; }
    }
}
