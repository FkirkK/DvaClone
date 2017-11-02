using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DvaWebApp.Models
{
    public class AlgorithmSettingsModel
    {
        public SelectList FeatureSetList { get; set; }
        public SelectList ClassificationList { get; set; }
        public string SelectedFeatureSet { get; set; }
        public string SelectedClassification { get; set; }

    }
}
