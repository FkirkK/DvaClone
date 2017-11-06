using System;
using System.Diagnostics;
using DvaCore;
using Microsoft.AspNetCore.Mvc;
using DvaCore.Models;
using DvaWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using DvaAnalysis;
using System.Collections.Generic;

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
            AlgorithmSettingsModel model = new AlgorithmSettingsModel
            {
                AlgorithmSettings = new List<SingleAlgorithmSettings>()
            };

            for (int i = 0; i < int.Parse(dism.SelectedAlgorithmCount); i++)
            {
                model.AlgorithmSettings.Add(new SingleAlgorithmSettings());
            }


            return View(model);
        }

        [HttpPost]
        public IActionResult DeceptionAnalysisResult(AlgorithmSettingsModel asm)
        {
            FeatureSet selectedFeatureSet = (FeatureSet) Enum.Parse(typeof(FeatureSet), asm.AlgorithmSettings[0].SelectedFeatureSet);
            Classification selectedClassification = (Classification) Enum.Parse(typeof(Classification), asm.AlgorithmSettings[0].SelectedClassification);

            IAnalysisRunner runner = new AnalysisRunner();
            PythonConfiguration config = new PythonConfiguration(selectedClassification, selectedFeatureSet);
            var result = runner.RunAnalysis(new List<AnalysisConfiguration>() { config }, new Judge()); //TODO: Use the actual choice of judge
            ViewBag.LinearSvmResult = result;

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
