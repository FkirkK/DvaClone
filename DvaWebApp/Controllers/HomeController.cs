using System;
using System.Diagnostics;
using DvaCore;
using Microsoft.AspNetCore.Mvc;
using DvaCore.Models;
using DvaWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using DvaAnalysis;

namespace DvaWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult DeceptionAnalysis()
        {
            AlgorithmSettingsModel model = new AlgorithmSettingsModel
            {
                ClassificationList = new SelectList(Enum.GetNames(typeof(Classification))),
                FeatureSetList = new SelectList(Enum.GetNames(typeof(FeatureSet)))
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult DeceptionAnalysisResult(AlgorithmSettingsModel asm)
        {
            FeatureSet selectedFeatureSet = (FeatureSet) Enum.Parse(typeof(FeatureSet), asm.SelectedFeatureSet);
            Classification selectedClassification = (Classification) Enum.Parse(typeof(Classification), asm.SelectedClassification);

            IAnalysisRunner runner = new AnalysisRunner(new PythonRunner(), new Judge());
            PythonConfiguration config = new PythonConfiguration(selectedClassification, selectedFeatureSet);
            var result = runner.RunAnalysis(config);
            ViewBag.LinearSvmResult = result;

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
