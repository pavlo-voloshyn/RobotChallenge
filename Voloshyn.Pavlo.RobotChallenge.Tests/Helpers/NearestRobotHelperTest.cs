using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voloshyn.Pavlo.RobotChallenge.Helpers;

namespace Voloshyn.Pavlo.RobotChallenge.Tests.Helpers
{
    public class NearestRobotHelperTest
    {
        [Test]
        public void Find_ZeroRobots_ReturnEmptyList()
        {
            //Arrange
            var robots = new List<Robot.Common.Robot>();
            var myRobot = new Robot.Common.Robot();
            int count = 1;

            //Act
            var result = NearestRobotsHelper.Find(robots, myRobot, count);

            //Assert
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void Find_TakeZero_ReturnEmptyList()
        {
            //Arrange
            var robots = new List<Robot.Common.Robot>()
            {
                new Robot.Common.Robot()
                {
                    Position = new Robot.Common.Position(0, 2),
                    Energy = 1000
                },
            };
            var myRobot = new Robot.Common.Robot()
            {
                Position = new Robot.Common.Position(0, 0)
            };
            int count = 0;

            //Act
            var result = NearestRobotsHelper.Find(robots, myRobot, count);

            //Assert
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void Find_ListContainsMatchedRobots_ReturnEmptyList()
        {
            //Arrange
            var robots = new List<Robot.Common.Robot>()
            {
                new Robot.Common.Robot()
                {
                    Position = new Robot.Common.Position(0, 2),
                    Energy = 1000
                },
            };
            var myRobot = new Robot.Common.Robot()
            {
                Position = new Robot.Common.Position(0, 0)
            };
            int count = 1;

            //Act
            var result = NearestRobotsHelper.Find(robots, myRobot, count);

            //Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(robots.First(), result.First());
        }
    }
}
