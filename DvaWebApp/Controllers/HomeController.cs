using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DvaCore;
using Microsoft.AspNetCore.Mvc;
using DvaCore.Models;
using DvaDataImporter;
using DvaPythonRunner;
using DvaWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            model.AlgorithmList = new SelectList(new[] { "Linear SVM (Unigram)", "Linear SVM (Bigram)", "Linear SVM (Trigram)", "Linear SVM (Bigram+)", "Linear SVM (Trigram+)" });
            return View(model);
        }

        [HttpPost]
        public IActionResult LinearSVMResult(AlgorithmSettingsModel asm)
        {
            string selectedAlgorithm = asm.SelectedAlgorithm;
            IAnalysisRunner runner = new LocalAnalysisRunner(new PythonRunner(), new Judge());
            IResult result = null;

            switch (selectedAlgorithm)
            {
                case "Linear SVM (Unigram)":
                    result = runner.RunLinearSvmUnigram();
                    break;
                case "Linear SVM (Bigram)":
                    result = runner.RunLinearSvmBigram();
                    break;
                case "Linear SVM (Trigram)":
                    result = runner.RunLinearSvmTrigram();
                    break;
                case "Linear SVM (Bigram+)":
                    result = runner.RunLinearSvmBigramPlus();
                    break;
                case "Linear SVM (Trigram+)":
                    result = runner.RunLinearSvmTrigramPlus();
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
