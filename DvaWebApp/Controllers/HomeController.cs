﻿using System;
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
            //ViewBag.MethodName = new SelectList(new[] {
            //"LinearSVMResult", "LinearSVMResult1", "LinearSVMResult2"});
            //return View(new DummyModel());
            return View();
            }

        [HttpPost]
        public IActionResult LinearSVMResult(string methodName)
        {
            IAnalysisRunner runner = new AnalysisRunner(new PythonRunner(), new Judge());
            IResult result = runner.RunLinearSvmBigram();
            ViewBag.LinearSvmResult = result;

            return View();
        }

        [HttpPost]
        public IActionResult LinearSVMResult1()
        {
            IAnalysisRunner runner = new AnalysisRunner(new PythonRunner(), new Judge());
            //IResult result = runner.RunLinearSvm();
            //ViewBag.LinearSvmResult = result;

            return View();
        }

        [HttpPost]
        public IActionResult LinearSVMResult2()
        {
            IAnalysisRunner runner = new AnalysisRunner(new PythonRunner(), new Judge());
            //IResult result = runner.RunLinearSvm();
            //ViewBag.LinearSvmResult = result;

            return View();
        }

        public IActionResult Eksempel(int firstnumber = 0, int secondnumber = 0)
        {
            ViewData["Message"] = "Your application description page.";
            int result = firstnumber + secondnumber;
            ViewBag.res = result;

            DataImporter di = new DataImporter();
            ViewBag.reviews = di.ImportReviews(@"C:\Users\marcb\Documents\GitHub\Dva\op_spam_v1.4");

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}