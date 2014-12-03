using System.Collections.Generic;
using MVCTraining.Web.Core.Models;

namespace MVCTraining.Web.Core.Domain
{
    public class Mars : PlanetBase
    {
        public Mars() : base(
            new SurfaceModel() { Width = 10, Height = 10}, 
            new List<CoordinateModel>()
            {
                new CoordinateModel(){X = 3, Y = 3}
            })
        {
        }
    }
}