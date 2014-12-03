using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCTraining.Web.Core.Domain;
using MVCTraining.Web.Core.Models;

namespace MVCTraining.MarsRover.Web.Api
{
    [RoutePrefix("api/rover")]
    public class RoverController : ApiController
    {
        private readonly IRover _rover;
        private readonly IPlanet _planet;

        public RoverController(IRover rover, IPlanet planet)
        {
            _rover = rover;
            _planet = planet;
        }

        [Route("position")]
        [HttpPost]
        public PositionModel GetPosition([FromBody] CommandViewModel command)
        {
            if (command != null)
            {
                var list = command.Text.Select(c => c.ToString()).ToList();
                _rover.Move(list);
            }
            
            return _rover.GetPosition();
        }


        [Route("reset")]
        [HttpPost]
        public PositionModel ResetPosition()
        {
            _rover.Reset();
            return _rover.GetPosition();
        }

        [Route("grid")]
        [HttpGet]
        public SurfaceModel GetPlanetGrid()
        {
            
            return _planet.GetSurface();
        }


    }

    public class CommandViewModel
    {
        public string Text;
    }
}
