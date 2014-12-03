using System.Collections.Generic;
using System.Web.Http;
using SPA.Core.Models;
using SPA.Infra.Services;
using SPA.Web.Models;

namespace SPA.Web.Api
{
    [RoutePrefix("api/someprefix")]
    public class DoSomethingController : ApiController
    {
        private readonly IDoSomethingService _doSomethingService;

        public DoSomethingController(IDoSomethingService doSomethingService)
        {
            _doSomethingService = doSomethingService;
        }

        [Route("items")]
        [HttpGet]
        public IEnumerable<SampleModel> GetContext()
        {
            return _doSomethingService.ReturnSomething();
        }
    }
}
