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
        public AlgorithmSettingsModel()
        {
            AlgorithmSettings = new List<SingleAlgorithmSettings>();
        }
        public List<SingleAlgorithmSettings> AlgorithmSettings { get; set; }
        public string SelectedCommittee { get; set; }
    }

    public class SingleAlgorithmSettings
    {
        public SingleAlgorithmSettings()
        {
            FeatureSetList = new SelectList(Enum.GetNames(typeof(FeatureSet)));

            ClassificationList = GetPrettyClassificationList();
        }

        public SelectList FeatureSetList { get; set; }
        public SelectList ClassificationList { get; set; }
        public string SelectedFeatureSet { get; set; }
        public string SelectedClassification { get; set; }
        public double SelectedWeight { get; set; }

        private SelectList GetPrettyClassificationList()
        {
            var listOfClassifications = Enum.GetValues(typeof(Classification));
            List<string> prettyClassificationList = new List<string>();

            foreach (var c in listOfClassifications)
            {
                prettyClassificationList.Add(((Classification)c).Prettify());
            }

            return new SelectList(prettyClassificationList);
        }
    }
}
