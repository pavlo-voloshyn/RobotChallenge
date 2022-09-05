using Robot.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voloshyn.Pavlo.RobotChallenge.Helpers;

namespace Voloshyn.Pavlo.RobotChallenge
{
    public class VoloshynAlgorithm : IRobotAlgorithm
    {
        public string Author => "Voloshyn Pavlo";

        public RobotCommand DoStep(IList<Robot.Common.Robot> robots, int robotToMoveIndex, Map map)
        {
            var myRobot = robots[robotToMoveIndex];
            var myRobots = robots.Where(x => x.OwnerName == myRobot.OwnerName).ToList();
            var nearestStation = NearestStationHelper.Find(map, myRobot);
            int distanceToNearestStation = FindDistanceHelper.Find(myRobot.Position, nearestStation.Position);
            var nearestRobots = NearestRobotsHelper.Find(robots, myRobot, Constants.TakeNearestRobot);

            nearestRobots = nearestRobots
                .OrderByDescending(x => x.Energy)
                .ToList();

            int energyFromFightEnemyRobot = 0;
            Robot.Common.Robot robotToFight = null;

            if (nearestRobots.Any())
            {
                foreach (var robot in nearestRobots)
                {
                    int energyProfit = (int)(robot.Energy * Constants.ProfitFromAttactPercentage) 
                        - Constants.SpendingEnergyWhileAttack
                        - FindDistanceHelper.Find(myRobot.Position, robot.Position);
                    if (energyProfit < 0) continue;
                    if (energyProfit > energyFromFightEnemyRobot)
                    {
                        energyFromFightEnemyRobot = energyProfit;
                        robotToFight = robot;
                    }
                }
            }

            if (myRobots.Count == 100)
            {
                if (FindDistanceHelper.Find(myRobot.Position, nearestStation.Position) != 0
                    && !myRobots.Any(r => FindDistanceHelper.Find(r.Position, nearestStation.Position) == 0))
                {
                    return new MoveCommand() { NewPosition = nearestStation.Position };
                }
            }

            if (myRobot.Energy > Constants.EnergyNewRobotCreate && myRobots.Count < 100)
            {
                return new CreateNewRobotCommand()
                {
                    NewRobotEnergy = Constants.EnergyNewRobot
                };
            }
            else if (energyFromFightEnemyRobot >= Constants.EnergyToFight && robotToFight != null)
            {
                return new MoveCommand() { NewPosition = robotToFight.Position };
            }
            else if (distanceToNearestStation < Constants.CollectEnergyDistance && nearestStation.Energy > 0)
            {
                return new CollectEnergyCommand();
            }
            else if (!myRobots.Any(r => FindDistanceHelper.Find(r.Position, nearestStation.Position) == 0))
            {
                return new MoveCommand() { NewPosition = nearestStation.Position };
            }
            else 
            {
                return new MoveCommand() { NewPosition = map.FindFreeCell(myRobot.Position, robots) };
            }
        }
    }
}
