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
using DvaWeb.Models;

namespace DvaWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult LinearSVM()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LinearSVMResult()
        {
            //var runner = new AnalysisRunner(new PythonRunner());
            //var result = runner.RunLinearSvm();
            //ViewBag.Docs = result.RatedDocuments;
            ViewBag.Docs = new List<RatedDocument>
            {
                (new RatedDocument("Hello", true, true)),
                (new RatedDocument("It's me", true, true)),
                (new RatedDocument("I've been wondering", true, true))
            };

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
