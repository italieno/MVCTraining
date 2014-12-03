using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MVCTraining.Web.Core.Domain;
using MVCTraining.Web.Core.Models;
using SPA.Infra.Services;
using MVCTraining.Web.Core.Constants;

namespace SPA.Web.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IPlanet>().ImplementedBy<Mars>(),
                Component.For<IRover>().ImplementedBy<Rover>().DependsOn(new
                {
                    startPosition = new PositionModel()
                    {
                        Coordinates = new CoordinateModel() {X = 0, Y = 0},
                        Orientation = RoverConstants.Orientation.N
                    }
                })
                );
        }
    }
}