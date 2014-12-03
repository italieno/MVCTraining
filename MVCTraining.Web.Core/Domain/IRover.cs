using System.Collections.Generic;
using MVCTraining.Web.Core.Models;

namespace MVCTraining.Web.Core.Domain
{
    public interface IRover
    {
        PositionModel GetPosition();
        void Move(List<string> instructions);
        void Reset();
    }
}