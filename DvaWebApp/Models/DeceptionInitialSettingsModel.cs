using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using DvaAnalysis.Committees;

namespace DvaWebApp.Models
{
    public class DeceptionInitialSettingsModel
    {
        public DeceptionInitialSettingsModel()
        {
            CommitteeList = new SelectList(Enum.GetNames(typeof(Committee)));
        }
        public SelectList CommitteeList { get; set; }
        public string SelectedCommittee { get; set; }
        public string SelectedAlgorithmCount { get; set; }
    }
}
