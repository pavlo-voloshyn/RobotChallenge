using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voloshyn.Pavlo.RobotChallenge.Helpers
{
    public static class NearestRobotsHelper
    {
        public static List<Robot.Common.Robot> Find(IList<Robot.Common.Robot> robots, Robot.Common.Robot myRobot, int count)
        {
            if (count <= 0) return new List<Robot.Common.Robot>();
            Dictionary<Robot.Common.Robot, int> robotDistance = new Dictionary<Robot.Common.Robot, int>();
            
            foreach (var robot in robots)
            {
                if (robot.OwnerName != Constants.MyName)
                robotDistance.Add(robot, FindDistanceHelper.Find(myRobot.Position, robot.Position));
            }

            robotDistance = robotDistance
                .Where(r => r.Key.Energy >= Constants.MinEnemyEnergy)
                .OrderBy(r => r.Value)
                .ToDictionary(r => r.Key, r => r.Value);

            return robotDistance.Keys.Take(count).ToList();
        }
    }
}
