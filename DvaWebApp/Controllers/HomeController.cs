using System;
using System.Diagnostics;
using DvaCore;
using Microsoft.AspNetCore.Mvc;
using DvaCore.Models;
using DvaWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using DvaAnalysis;
using System.Collections.Generic;
using System.Linq;

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

            model.SelectedJudge = dism.SelectedJudge;

            return View(model);
        }

        [HttpPost]
        public IActionResult DeceptionAnalysisResult(AlgorithmSettingsModel asm)
        {
            var v = ViewBag;
            Judge selectedJudge = (Judge)Enum.Parse(typeof(Judge), asm.SelectedJudge);
            IAnalysisRunner runner = new AnalysisRunner();
            List<AnalysisConfiguration> configs = new List<AnalysisConfiguration>();

            foreach (var algSetting in asm.AlgorithmSettings)
            {
                FeatureSet selectedFeatureSet = (FeatureSet)Enum.Parse(typeof(FeatureSet), algSetting.SelectedFeatureSet);
                Classification selectedClassification = (Classification)Enum.Parse(typeof(Classification), algSetting.SelectedClassification);

                PythonConfiguration config = new PythonConfiguration(selectedClassification, selectedFeatureSet);
                configs.Add(config);
            }

            IJudge judge;

            switch (selectedJudge)
            {
                case Judge.DummyJudge:
                    judge = new DummyJudge();
                    break;
                case Judge.MajorityJudge:
                    judge = new MajorityJudge();
                    break;
                case Judge.WeightedJudge:
                    var weightList = asm.AlgorithmSettings.ConvertAll(x => x.SelectedWeight);
                    judge = new WeightedJudge(weightList);
                    break;
                default:
                    throw new ArgumentNullException("No valid judge selected.");
            }

            var result = runner.RunAnalysis(configs, judge); 
            ViewBag.ClassifierResult = result;

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
