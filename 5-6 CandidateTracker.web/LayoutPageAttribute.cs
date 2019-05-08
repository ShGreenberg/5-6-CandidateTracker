using _5_6_CandidateTracker.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5_6_CandidateTracker.web
{
    public class LayoutPageAttribute: ActionFilterAttribute
    {
        private string _connString;
        public LayoutPageAttribute(IConfiguration configuration)
        {
            _connString = configuration.GetConnectionString("ConStr");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = (Controller)context.Controller;
            CandidateRepository rep = new CandidateRepository(_connString);
            controller.ViewBag.Pending = rep.GetPendingCandidates().Count();
            controller.ViewBag.Confirmed = rep.GetConfirmedCandidates().Count();
            controller.ViewBag.Declined = rep.GetDeclinedCandidates().Count();
        }
    }
}
