using Robot.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voloshyn.Pavlo.RobotChallenge.Helpers
{
    public static class NearestStationHelper
    {
        public static EnergyStation Find(Map map, Robot.Common.Robot robot)
        {
            EnergyStation nearestStation = map.Stations.FirstOrDefault();
            if (nearestStation == null)
            {
                return nearestStation;
            }

            int nearestDistance = FindDistanceHelper.Find(robot.Position, nearestStation.Position);

            foreach (EnergyStation energyStation in map.Stations)
            {
                int distance = FindDistanceHelper.Find(robot.Position, energyStation.Position);

                if (distance < nearestDistance)
                {
                    nearestStation = energyStation;
                    nearestDistance = distance;
                } 
            }

            return nearestStation;
        }
    }
}
