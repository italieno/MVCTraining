using System.Collections.Generic;
using MVCTraining.Web.Core.Models;

namespace MVCTraining.Web.Core.Domain
{
    public class PlanetBase : IPlanet
    {
        private readonly SurfaceModel _planetSurface;
        private readonly List<CoordinateModel> _obstacles;

        public PlanetBase(SurfaceModel surface, List<CoordinateModel> obstacles)
        {
            _planetSurface = surface;
            _obstacles = obstacles;
        }

        public SurfaceModel GetSurface()
        {
            return _planetSurface;
        }

        public IEnumerable<CoordinateModel> GetObstacles()
        {
            return _obstacles;
        }
    }
}