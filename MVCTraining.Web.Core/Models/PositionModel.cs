using MVCTraining.Web.Core.Constants;

namespace MVCTraining.Web.Core.Models
{
    public class PositionModel
    {
        public CoordinateModel Coordinates { get; set; }
        public RoverConstants.Orientation Orientation { get; set; }
    }
}