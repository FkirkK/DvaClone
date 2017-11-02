using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DvaWebApp.Models
{
    public class DeceptionInitialSettingsModel
    {
        public DeceptionInitialSettingsModel()
        {
            JudgeList = new SelectList(new string[] { "Judge1" });
        }
        public SelectList JudgeList { get; set; }
        public string SelectedJudge { get; set; }
        public string SelectedAlgorithmCount { get; set; }
    }
}
