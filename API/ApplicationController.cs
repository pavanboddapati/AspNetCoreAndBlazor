using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAssessment.Models;
using AppAssessment.Models.DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAssessment.API
{
    [Route("api/[controller]")]
    public class ApplicationController : Controller
    {
        private readonly IApplicationRepository repo;

        public ApplicationController(IApplicationRepository repo)
        {
            this.repo = repo;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Application> Get()
        {
            return repo.GetApplications(); 
        }
    }
}
