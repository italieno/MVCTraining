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
    public class Rover_Wrapping_Test
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
        public void It_Should_Be_Able_To_Wrap_Planet_Surface_With_Command_B()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.B.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(_mars.GetSurface().Height, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.N, position.Orientation);
        }

        [Test]
        public void It_Should_Be_Able_To_Wrap_Planet_Surface_With_Command_RB()
        {
            var instructions = new List<string>()
            {
                 RoverConstants.Command.R.ToString(),
                RoverConstants.Command.B.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(_mars.GetSurface().Width, position.Coordinates.X);
            Assert.AreEqual(0, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.W, position.Orientation);
        }

        [Test]
        public void It_Should_Be_Able_To_Wrap_Planet_Surface_With_Command_FFFFFFFFFFF()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(0, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.N, position.Orientation);
        }

        [Test]
        public void It_Should_Be_Able_To_Wrap_Planet_Surface_With_Command_RFFFFFFFFFFF()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(0, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.W, position.Orientation);
        }

    }
}
