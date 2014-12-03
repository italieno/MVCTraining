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
    public class Rover_Positions_Test
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
        public void It_Should_Have_Some_Position()
        {
            PositionModel position = _rover.GetPosition();
            Assert.IsTrue(position != null);
        }

        [Test]
        public void It_Should_Have_Default_Starting_Position_0_0_N()
        {
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(0, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.N, position.Orientation);
        }

        [Test]
        public void It_Should_Be_Able_To_Move_Front_With_Command_F()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.F.ToString()
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(1, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.N, position.Orientation);
        }

        [Test]
        public void It_Should_Be_Able_To_Move_Back_With_Command_B()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.B.ToString()
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(_mars.GetSurface().Height, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.N, position.Orientation);
        }

        [Test]
        public void Given_the_command_FFFFBB_would_put_the_rover_at_2_0_N()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.B.ToString(),
                RoverConstants.Command.B.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(2, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.N, position.Orientation);
        }


        [Test]
        public void Given_the_command_FF__R__FF___would_put_the_rover_at_2_2_W()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString()
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(2, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.N, position.Orientation);

            instructions = new List<string>()
            {
                RoverConstants.Command.R.ToString()
            };

            _rover.Move(instructions);
            position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(2, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.W, position.Orientation);

            instructions = new List<string>()
            {
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString()
            };

            _rover.Move(instructions);
            position = _rover.GetPosition();
            Assert.AreEqual(2, position.Coordinates.X);
            Assert.AreEqual(2, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.W, position.Orientation);
        }


        [Test]
        public void Given_the_command_FFFFBB_would_put_the_rover_at_2_0_N_and_then_Reset_Explicitly()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.F.ToString(),
                RoverConstants.Command.B.ToString(),
                RoverConstants.Command.B.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(2, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.N, position.Orientation);

            _rover.Reset();
            position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(0, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.N, position.Orientation);
        }

    }
}
