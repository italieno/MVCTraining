using System.Collections.Generic;
using System.Linq;
using MVCTraining.Web.Core.Constants;
using MVCTraining.Web.Core.Models;

namespace MVCTraining.Web.Core.Domain
{
    public class Rover : IRover
    {
        private PositionModel _position;
        private readonly PositionModel _startingPosition;
        private readonly IPlanet _planet;

        public Rover(PositionModel startPosition, IPlanet planet)
        {
            _position = startPosition;
            _startingPosition = startPosition;
            _planet = planet;
        }

        public PositionModel GetPosition()
        {
            return _position;
        }

        public void Move(List<string> instructions)
        {
            var newCoordinates = _position.Coordinates;
            var newOrientation = _position.Orientation;

            foreach (var command in instructions)
            {

                if (command == RoverConstants.Command.F.ToString()) 
                   newCoordinates = GetCoordinatesMovingForward();

                if (command == RoverConstants.Command.B.ToString())
                    newCoordinates = GetCoordinatesMovingBackward();

                if (command == RoverConstants.Command.R.ToString())
                    newOrientation = GetOrientationTurningClockWise();

                if (command == RoverConstants.Command.L.ToString())
                    newOrientation = GetOrientationTurningAntiClockWise();

                var newPosition = new PositionModel()
                {
                    Coordinates = RecalculateCoordinatesIfWrapping(newCoordinates),
                    Orientation = newOrientation
                };

                if (!ExistObstacle(newPosition))
                    _position = newPosition;
                else
                    break;
                
            }
        }

        public void Reset()
        {
            _position = _startingPosition;
        }

        private bool ExistObstacle(PositionModel newPosition)
        {
            return _planet.GetObstacles().Any(obstacle => obstacle.X == newPosition.Coordinates.X && obstacle.Y == newPosition.Coordinates.Y);
        }

        private RoverConstants.Orientation GetOrientationTurningAntiClockWise()
        {
            switch (_position.Orientation)
            {
                case RoverConstants.Orientation.N:
                    return RoverConstants.Orientation.E;

                case RoverConstants.Orientation.E:
                    return RoverConstants.Orientation.S;

                case RoverConstants.Orientation.S:
                    return RoverConstants.Orientation.W;

                case RoverConstants.Orientation.W:
                    return RoverConstants.Orientation.N;
            }

            return RoverConstants.Orientation.N;
        }

        private RoverConstants.Orientation GetOrientationTurningClockWise()
        {
            switch (_position.Orientation)
            {
                 case RoverConstants.Orientation.N:
                    return RoverConstants.Orientation.W;

                 case RoverConstants.Orientation.W:
                    return RoverConstants.Orientation.S;

                 case RoverConstants.Orientation.S:
                    return RoverConstants.Orientation.E;

                 case RoverConstants.Orientation.E:
                    return RoverConstants.Orientation.N;
            }

            return RoverConstants.Orientation.N;
        }

        private CoordinateModel GetCoordinatesMovingBackward()
        {
            switch (_position.Orientation)
            {
                case RoverConstants.Orientation.N:
                    
                    return new CoordinateModel()
                    {
                        X = _position.Coordinates.X,
                        Y = _position.Coordinates.Y - 1
                    };
                   
                case RoverConstants.Orientation.E:

                    return new CoordinateModel()
                    {
                        X = _position.Coordinates.X + 1,
                        Y = _position.Coordinates.Y
                    };

                case RoverConstants.Orientation.S:

                    return new CoordinateModel()
                    {
                        X = _position.Coordinates.X,
                        Y = _position.Coordinates.Y + 1
                    };

                case RoverConstants.Orientation.W:

                    return new CoordinateModel()
                    {
                        X = _position.Coordinates.X - 1,
                        Y = _position.Coordinates.Y
                    };
            }

            return _position.Coordinates;
        }

        private CoordinateModel GetCoordinatesMovingForward()
        {
            switch (_position.Orientation)
            {
                case RoverConstants.Orientation.N:
                    return new CoordinateModel()
                    {
                        X = _position.Coordinates.X,
                        Y = _position.Coordinates.Y + 1
                    };

                case RoverConstants.Orientation.E:
                    return new CoordinateModel()
                    {
                        X = _position.Coordinates.X - 1,
                        Y = _position.Coordinates.Y
                    };

                case RoverConstants.Orientation.S:
                    return new CoordinateModel()
                    {
                        X = _position.Coordinates.X,
                        Y = _position.Coordinates.Y - 1
                    };

                case RoverConstants.Orientation.W:
                    return new CoordinateModel()
                    {
                        X = _position.Coordinates.X + 1,
                        Y = _position.Coordinates.Y
                    };
            }

            return _position.Coordinates;

        }

        private CoordinateModel RecalculateCoordinatesIfWrapping(CoordinateModel coordinates)
        {
            var planetSurface = _planet.GetSurface();

            if (coordinates.X == -1)
                coordinates.X = planetSurface.Width;

            if (coordinates.Y == -1)
                coordinates.Y = planetSurface.Height;

            if (coordinates.X > planetSurface.Width)
                coordinates.X = 0;

            if (coordinates.Y > planetSurface.Height)
                coordinates.Y = 0;

            return new CoordinateModel()
            {
                X = coordinates.X,
                Y = coordinates.Y
            };
        }
    }
}