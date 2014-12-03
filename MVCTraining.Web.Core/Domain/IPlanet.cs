using System.Collections.Generic;
using MVCTraining.Web.Core.Models;

namespace MVCTraining.Web.Core.Domain
{
    public interface IPlanet
    {
        SurfaceModel GetSurface();
        IEnumerable<CoordinateModel> GetObstacles();
    }
}