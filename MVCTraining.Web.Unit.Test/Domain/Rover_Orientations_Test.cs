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
    public class Rover_Orientations_Test
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
        public void It_Should_Be_Able_To_Turn_ClockWise_With_Command_R()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.R.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(0, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.W, position.Orientation);
        }

        [Test]
        public void It_Should_Be_Able_To_Turn_ClockWise_With_Command_RR()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.R.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(0, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.S, position.Orientation);
        }

        [Test]
        public void It_Should_Be_Able_To_Turn_ClockWise_With_Command_RRR()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.R.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(0, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.E, position.Orientation);
        }

        [Test]
        public void It_Should_Be_Able_To_Turn_ClockWise_With_Command_RRRR()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.R.ToString()
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(0, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.N, position.Orientation);
        }

        [Test]
        public void It_Should_Be_Able_To_Turn_AntiClockWise_With_Command_L()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.L.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(0, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.E, position.Orientation);
        }

        [Test]
        public void It_Should_Be_Able_To_Turn_AntiClockWise_With_Command_LL()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.L.ToString(),
                RoverConstants.Command.L.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(0, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.S, position.Orientation);
        }

        [Test]
        public void It_Should_Be_Able_To_Turn_AntiClockWise_With_Command_LLL()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.L.ToString(),
                RoverConstants.Command.L.ToString(),
                RoverConstants.Command.L.ToString()
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(0, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.W, position.Orientation);
        }

        [Test]
        public void It_Should_Be_Able_To_Turn_AntiClockWise_With_Command_LLLL()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.L.ToString(),
                RoverConstants.Command.L.ToString(),
                RoverConstants.Command.L.ToString(),
                RoverConstants.Command.L.ToString()
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(0, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.N, position.Orientation);
        }

        [Test]
        public void It_Should_Be_Able_To_Turn_ClockWise_And_Move_Front_With_Command_RF()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.F.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(1, position.Coordinates.X);
            Assert.AreEqual(0, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.W, position.Orientation);
        }

        [Test]
        public void It_Should_Be_Able_To_Turn_ClockWise_And_Move_Front_With_Command_RRF()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.F.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(_mars.GetSurface().Height, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.S, position.Orientation);
        }

        [Test]
        public void It_Should_Be_Able_To_Turn_ClockWise_And_Move_Front_With_Command_RRRF()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.F.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(_mars.GetSurface().Width, position.Coordinates.X);
            Assert.AreEqual(0, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.E, position.Orientation);
        }

        [Test]
        public void It_Should_Be_Able_To_Turn_ClockWise_And_Move_Back_With_Command_RB()
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
        public void It_Should_Be_Able_To_Turn_ClockWise_And_Move_Back_With_Command_RRB()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.B.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(0, position.Coordinates.X);
            Assert.AreEqual(1, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.S, position.Orientation);
        }

        [Test]
        public void It_Should_Be_Able_To_Turn_ClockWise_And_Move_Back_With_Command_RRRB()
        {
            var instructions = new List<string>()
            {
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.R.ToString(),
                RoverConstants.Command.B.ToString(),
            };

            _rover.Move(instructions);
            var position = _rover.GetPosition();
            Assert.AreEqual(1, position.Coordinates.X);
            Assert.AreEqual(0, position.Coordinates.Y);
            Assert.AreEqual(RoverConstants.Orientation.E, position.Orientation);
        }


       
    }
}
