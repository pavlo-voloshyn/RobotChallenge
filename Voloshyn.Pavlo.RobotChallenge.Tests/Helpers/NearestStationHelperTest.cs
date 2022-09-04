using NUnit.Framework;
using Robot.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voloshyn.Pavlo.RobotChallenge.Helpers;

namespace Voloshyn.Pavlo.RobotChallenge.Tests.Helpers
{
    public class NearestStationHelperTest
    {
        [Test]
        public void Find_MapContainsStations_ReturnNearest()
        {
            //Arrange
            EnergyStation expectedNearestStation = new EnergyStation()
            {
                Position = new Position(2, 3)
            };
            Map map = new Map()
            {
                Stations = new List<EnergyStation>()
                {
                    new EnergyStation()
                    {
                        Position = new Position(5, 5)
                    },
                    expectedNearestStation
                }
            };
            var robot = new Robot.Common.Robot()
            {
                Position = new Position(1, 1)
            };

            //Act
            var result = NearestStationHelper.Find(map, robot);

            //Assert
            Assert.AreEqual(expectedNearestStation, result);
        }

        [Test]
        public void Find_MapContainsNoStations_ReturnNull()
        {
            //Arrange

            Map map = new Map();
            var robot = new Robot.Common.Robot()
            {
                Position = new Position(1, 1)
            };

            //Act
            var result = NearestStationHelper.Find(map, robot);

            //Assert
            Assert.IsNull(result);
        }
    }
}
