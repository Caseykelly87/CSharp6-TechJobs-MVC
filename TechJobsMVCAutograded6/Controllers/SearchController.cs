using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVCAutograded6.Data;
using TechJobsMVCAutograded6.Models;

namespace TechJobsMVCAutograded6.Controllers;

public class SearchController : Controller
{
    // GET: /<controller>/
    
    public IActionResult Index()
    {
        
        ViewBag.columns = ListController.ColumnChoices;
        return View();
    }

    
    public IActionResult Results(string searchType, string searchTerm)
    {
        List<Job> jobs = new();

        if (searchTerm == "all" || String.IsNullOrEmpty(searchTerm))
        {
            jobs = JobData.FindAll();
            ViewBag.Title="All Jobs.";
        }
        else
        {
            jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            ViewBag.Title= jobs.Count() != 0 ? $"Jobs available for {searchType}: {searchTerm}." : $"No results for {searchType}: {searchTerm}.";
        }
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.jobs = jobs;
            return View("Index");
        
    }
}
