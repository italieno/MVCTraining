using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MVCTraining.Web.Controllers
{
    public class HomeController : Controller
    {
        private List<FestiveDate> _festiveDate;
 
        public HomeController()
        {
            _festiveDate = new List<FestiveDate>()
            {
                new FestiveDate(){When = new DateTime(2013,9,5)},
                new FestiveDate(){When = new DateTime(2017,9,5)},
                new FestiveDate(){When = new DateTime(2016,9,5)},
                new FestiveDate(){When = new DateTime(2022,9,5)}
            };
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(new ExamViewModel());
        }

        public ActionResult Search(ExamViewModel examViewModel)
        {
            if (ModelState.IsValid)
            {
                var service = new FestiveService(_festiveDate);
                var nextFestiveDates = service.GetNextFestiveDate(examViewModel.DateInput);

                foreach (var date in nextFestiveDates)
                {
                    examViewModel.Result += date.When.ToShortDateString() + '\n';
                }
            }
            

            return View("Index", examViewModel);
        }

        [HttpPost]
        public ActionResult SearchAjax()
        {
            //decimal principle = Convert.ToDecimal(Request["txtAmount"].ToString());
            //decimal rate = Convert.ToDecimal(Request["txtRate"].ToString());
            //int time = Convert.ToInt32(Request["txtYear"].ToString());

            //decimal simpleInteresrt = (principle * time * rate) / 100;

            //StringBuilder sbInterest = new StringBuilder();
            //sbInterest.Append("<b>Amount :</b> " + principle + "<br/>");
            //sbInterest.Append("<b>Rate :</b> " + rate + "<br/>");
            //sbInterest.Append("<b>Time(year) :</b> " + time + "<br/>");
            //sbInterest.Append("<b>Interest :</b> " + simpleInteresrt);
            return Content("aaa");
        }
    }

    public class FestiveService
    {
        private readonly List<FestiveDate> _festiveDate;

        public FestiveService(List<FestiveDate> festiveDate)
        {
            _festiveDate = festiveDate;
        }

        public IEnumerable<FestiveDate> GetNextFestiveDate(DateTime inputDate)
        {
            return _festiveDate.Where(e => e.When > inputDate).OrderBy(e => e.When);
        }
    }

    //public class ResponseViewModel
    //{
    //    public ResponseViewModel()
    //    {
    //        Description = "please insert a date";
    //    }
    //    public string Description { get; set;  }
    //}

    public class ExamViewModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public DateTime DateInput { get; set; }
        public string Result;
    }

    public class FestiveDate
    {
        public DateTime When { get; set; }
    }
}