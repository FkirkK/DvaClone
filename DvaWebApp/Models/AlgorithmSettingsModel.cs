using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DvaWebApp.Models
{
    public class AlgorithmSettingsModel
    {
        public SelectList AlgorithmList { get; set; }
        public string SelectedAlgorithm { get; set; }
    }
}
