using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using DvaAnalysis.Committees;
using System.Collections.Generic;

namespace DvaWebApp.Models
{
    public class DeceptionInitialSettingsModel
    {
        public DeceptionInitialSettingsModel()
        {
            CommitteeList = GetPrettyCommitteeList();
        }
        public SelectList CommitteeList { get; set; }
        public string SelectedCommittee { get; set; }
        public string SelectedAlgorithmCount { get; set; }

        private SelectList GetPrettyCommitteeList()
        {
            var listOfCommittees = Enum.GetValues(typeof(Committee));
            List<string> prettyCommitteeList = new List<string>();

            foreach (var c in listOfCommittees)
            {
                prettyCommitteeList.Add(((Committee)c).Prettify());
            }

            return new SelectList(prettyCommitteeList);
        }
    }
}
