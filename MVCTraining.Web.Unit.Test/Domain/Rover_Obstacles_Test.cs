using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCTraining.Web.Core.Constants;
using MVCTraining.Web.Core.Domain;
using MVCTraining.Web.Core.Models;
using NUnit.Framework;

namespace MVCTraining.Web.Unit.Test.Domain
{
    [TestFixture]
    public class Rover_Obstacles_Test
    {
        
        private IRover _rover;
        private IPlanet _mars;

        [SetUp]
        public void Given_A_Rover()
        {
            _mars = new Mars();

            _rover = new Rover(new PositionModel()
            {
                Coordinates = new CoordinateModel(){X = 0,Y = 0},
                Orientation = RoverConstants.Orientation.N
            }, _mars);

        }

       
        [Test]
        public void Given_the_command_FFRFF_would_put_the_rover_at_2_2_W_Because_No_Obstacles()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(2, position.Coordinates.X);
            Assert.AreEqual(2, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.W, position.Orientation);
        }

        [Test]
        public void Given_the_command_FFFRFFF_would_put_the_rover_at_2_3_W_Because_Obstacle_Detected_At_3_3()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(2, position.Coordinates.X);
            Assert.AreEqual(3, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.W, position.Orientation);
        }


      
    }
}
