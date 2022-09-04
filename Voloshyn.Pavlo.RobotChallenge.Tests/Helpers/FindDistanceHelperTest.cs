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
    public class FindDistanceHelperTest
    {
        [Test]
        public void FindDistanceTest_ShouldCalcValue()
        {
            //Arrange
            Position p1 = new Position(1, 4);
            Position p2 = new Position(2, 8);
            int expected = 17;

            //Act
            int result = FindDistanceHelper.Find(p1, p2);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FindDistanceTest_ShouldReturnZero()
        {
            //Arrange
            Position p1 = new Position(1, 4);
            Position p2 = new Position(1, 4);
            int expected = 0;

            //Act
            int result = FindDistanceHelper.Find(p1, p2);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
