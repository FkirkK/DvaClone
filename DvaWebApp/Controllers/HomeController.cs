using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DvaWebApp.Models;
using DvaAnalysis;
using System.Collections.Generic;
using DvaAnalysis.Committees;

namespace DvaWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult DeceptionInitialSettings()
        {
            return View(new DeceptionInitialSettingsModel());
        }

        [HttpPost]
        public IActionResult DeceptionAnalysis(DeceptionInitialSettingsModel dism)
        {
            AlgorithmSettingsModel model = new AlgorithmSettingsModel();

            for (int i = 0; i < int.Parse(dism.SelectedAlgorithmCount); i++)
            {
                model.AlgorithmSettings.Add(new SingleAlgorithmSettings());
            }

            model.SelectedCommittee = dism.SelectedCommittee;

            return View(model);
        }

        [HttpPost]
        public IActionResult DeceptionAnalysisResult(AlgorithmSettingsModel asm)
        {
            var v = ViewBag;
            Committee selectedCommittee = (Committee)Enum.Parse(typeof(Committee), asm.SelectedCommittee);
            IAnalysisRunner runner = new AnalysisRunner();
            List<AnalysisConfiguration> configs = new List<AnalysisConfiguration>();

            foreach (var algSetting in asm.AlgorithmSettings)
            {
                FeatureSet selectedFeatureSet = (FeatureSet)Enum.Parse(typeof(FeatureSet), algSetting.SelectedFeatureSet);
                Classification selectedClassification = ClassificationExtension.Deprettify(algSetting.SelectedClassification);

                PythonConfiguration config = new PythonConfiguration(selectedClassification, selectedFeatureSet);
                configs.Add(config);
            }

            ICommittee committee;

            switch (selectedCommittee)
            {
                case Committee.MajorityCommittee:
                    committee = new MajorityCommittee();
                    break;
                case Committee.WeightedCommittee:
                    var weightList = asm.AlgorithmSettings.ConvertAll(x => x.SelectedWeight);
                    committee = new WeightedCommittee(weightList);
                    break;
                default:
                    throw new ArgumentNullException("No valid committee selected.");
            }

            var result = runner.RunAnalysis(configs, committee); 
            ViewBag.ClassifierResult = result;

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
