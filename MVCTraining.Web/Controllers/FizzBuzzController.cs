using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTraining.Web.Infra.Services;
using MVCTraining.Web.Unit.Test.Services;

namespace MVCTraining.Web.Controllers
{
    public class FizzBuzzController : Controller
    {
        private FizzBuzzViewModel _viewModel;
        private IFizzBuzzService _fizzBuzzService;

        public FizzBuzzController()
        {  
            _viewModel = new FizzBuzzViewModel();
            _fizzBuzzService = new FizzBuzzService();

        }
        // GET: FizzBuzz
        public ActionResult Index()
        {
            return View(_viewModel);
        }

        public ActionResult SolveTest(FizzBuzzViewModel fizzBuzzViewModel)
        {
            fizzBuzzViewModel.Answer = _fizzBuzzService.GetAnwser(fizzBuzzViewModel.InputNumber);
            return View("Index", fizzBuzzViewModel);
        }

    }

    public class FizzBuzzViewModel
    {
        public FizzBuzzViewModel()
        {
            Answer = "Insert an integer number";
        }

        public int InputNumber { get; set; }
        public string Answer { get; set; }
    }


}