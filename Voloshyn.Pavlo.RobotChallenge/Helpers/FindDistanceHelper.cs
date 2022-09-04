using Robot.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voloshyn.Pavlo.RobotChallenge.Helpers
{
    public static class FindDistanceHelper
    {
        public static int Find(Position p1, Position p2)
        {
            int x0 = p1.X;
            int y0 = p1.Y;
            int x = p2.X;
            int y = p2.Y;

            return (x - x0) * (x - x0) + (y - y0) * (y - y0);
        }
    }
}
