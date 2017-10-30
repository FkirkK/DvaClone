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
        
        public IActionResult LinearSVM()
        {
            AlgorithmSettingsModel model = new AlgorithmSettingsModel();
            model.AlgorithmList = new SelectList(new[] { "Linear SVM (Unigram)", "Linear SVM (Bigram)", "Linear SVM (Trigram)", "Linear SVM (Bigram+)", "Linear SVM (Trigram+)", "Decicion Tree (Unigram)" });
            return View(model);
        }

        [HttpPost]
        public IActionResult LinearSVMResult(AlgorithmSettingsModel asm)
        {
            string selectedAlgorithm = asm.SelectedAlgorithm;
            IAnalysisRunner runner = new AnalysisRunner(new PythonRunner(), new Judge());
            IResult result = null;
            PythonConfiguration config;

            switch (selectedAlgorithm)
            {
                case "Linear SVM (Unigram)":
                    config = new PythonConfiguration(Classification.LinearSVC, BagOfWords.Unigram);
                    result = runner.RunAnalysis(config);
                    break;
                case "Linear SVM (Bigram)":
                    config = new PythonConfiguration(Classification.LinearSVC, BagOfWords.Bigram);
                    result = runner.RunAnalysis(config);
                    break;
                case "Linear SVM (Trigram)":
                    config = new PythonConfiguration(Classification.LinearSVC, BagOfWords.Trigram);
                    result = runner.RunAnalysis(config);
                    break;
                case "Linear SVM (Bigram+)":
                    config = new PythonConfiguration(Classification.LinearSVC, BagOfWords.BigramPlus);
                    result = runner.RunAnalysis(config);
                    break;
                case "Linear SVM (Trigram+)":
                    config = new PythonConfiguration(Classification.LinearSVC, BagOfWords.TrigramPlus);
                    result = runner.RunAnalysis(config);
                    break;
                case "Decicion Tree (Unigram)":
                    config = new PythonConfiguration(Classification.DecisionTree, BagOfWords.Unigram);
                    result = runner.RunAnalysis(config);
                    break;
                default:
                    return Error();
            }
            
            ViewBag.LinearSvmResult = result;

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
