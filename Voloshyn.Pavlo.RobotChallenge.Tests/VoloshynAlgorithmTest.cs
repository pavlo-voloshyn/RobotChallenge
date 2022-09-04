using NUnit.Framework;
using Robot.Common;
using System.Collections.Generic;

namespace Voloshyn.Pavlo.RobotChallenge.Tests
{
    public class VoloshynAlgorithmTest
    {
        private IRobotAlgorithm _robotAlgorithm;
        [SetUp]
        public void Setup()
        {
            _robotAlgorithm = new VoloshynAlgorithm();
        }

        [Test]
        public void DoStepTest_ShouldFightRobot()
        {
            //Arrange 
            var robots = testRobots[0];
            var indexRobot = 0;
            var map = testMaps[1];
            var expectedCommand = expectedCommands[0];

            //Act
            var command = _robotAlgorithm.DoStep(robots, indexRobot, map);
            
            //Assert
            Assert.IsTrue(command.GetType() == expectedCommand.GetType());
        }

        [Test]
        public void DoStepTest_ShouldCreateNewRobot()
        {
            //Arrange 
            var robots = testRobots[1];
            var indexRobot = 0;
            var map = testMaps[1];
            var expectedCommand = expectedCommands[1];

            //Act
            var command = _robotAlgorithm.DoStep(robots, indexRobot, map);

            //Assert
            Assert.IsTrue(command.GetType() == expectedCommand.GetType());
        }

        [Test]
        public void DoStepTest_EnergyNotEnoughToCreateNew_ShouldFightRobot()
        {
            //Arrange 
            var robots = testRobots[2];
            var indexRobot = 0;
            var map = testMaps[1];
            var expectedCommand = expectedCommands[2];

            //Act
            var command = _robotAlgorithm.DoStep(robots, indexRobot, map);

            //Assert
            Assert.IsTrue(command.GetType() == expectedCommand.GetType());
        }

        [Test]
        public void DoStepTest_ShouldCollectEnergy()
        {
            //Arrange 
            var robots = testRobots[3];
            var indexRobot = 0;
            var map = testMaps[0];
            var expectedCommand = expectedCommands[3];

            //Act
            var command = _robotAlgorithm.DoStep(robots, indexRobot, map);

            //Assert
            Assert.IsTrue(command.GetType() == expectedCommand.GetType());
        }

        [Test]
        public void DoStepTest_MoveToEnergyStatio()
        {
            //Arrange 
            var robots = testRobots[4];
            var indexRobot = 0;
            var map = testMaps[1];
            var expectedCommand = expectedCommands[4];

            //Act
            var command = _robotAlgorithm.DoStep(robots, indexRobot, map);

            //Assert
            Assert.IsTrue(command.GetType() == expectedCommand.GetType());
        }

        private static readonly IList<Robot.Common.Robot>[] testRobots = new[]
        {
            new List<Robot.Common.Robot>(new[] {
                new Robot.Common.Robot()
                {
                    Position = new Position(0, 0),
                    Energy = 100,
                    OwnerName = Constants.MyName
                },
                new Robot.Common.Robot()
                {
                    Position = new Position(1, 0),
                    Energy = Constants.EnergyToFight + 200,
                    OwnerName = "Enemy"
                }
            }),
            new List<Robot.Common.Robot>(new[] {
                new Robot.Common.Robot()
                {
                    Position = new Position(0, 0),
                    Energy =  Constants.EnergyNewRobotCreate + 100,
                    OwnerName = Constants.MyName
                },
                new Robot.Common.Robot()
                {
                    Position = new Position(1, 0),
                    Energy = 20,
                    OwnerName = "Enemy"
                }
            }),
            new List<Robot.Common.Robot>(new[] {
                new Robot.Common.Robot()
                {
                    Position = new Position(0, 0),
                    Energy =  100,
                    OwnerName = Constants.MyName
                },
                new Robot.Common.Robot()
                {
                    Position = new Position(1, 0),
                    Energy =  Constants.EnergyToFight + Constants.MinEnergyToFight,
                    OwnerName = "Enemy"
                }
            }),
            new List<Robot.Common.Robot>(new[] {
                new Robot.Common.Robot()
                {
                    Position = new Position(0, 0),
                    Energy = 20,
                    OwnerName = Constants.MyName
                },
                new Robot.Common.Robot()
                {
                    Position = new Position(1, 0),
                    Energy = 20,
                    OwnerName = "Enemy"
                }
            }),
            new List<Robot.Common.Robot>(new[] {
                new Robot.Common.Robot()
                {
                    Position = new Position(0, 0),
                    Energy = 20,
                    OwnerName = Constants.MyName
                },
                new Robot.Common.Robot()
                {
                    Position = new Position(1, 0),
                    Energy = 20,
                    OwnerName = "Enemy"
                }
            }),
        };

        private static readonly Map[] testMaps = new[] {
            new Map()
            {
                Stations = new[]
                {
                    new EnergyStation()
                    {
                        Energy = 100,
                        Position = new Position(1, 0)
                    }
                }
            },
            new Map()
            {
                Stations = new[]
                {
                    new EnergyStation()
                    {
                        Energy = 100,
                        Position = new Position(10, 20)
                    }
                }
            }
        };

        private static readonly RobotCommand[] expectedCommands = new RobotCommand[]
        {
            new MoveCommand(),
            new CreateNewRobotCommand(),
            new MoveCommand(),
            new CollectEnergyCommand(),
            new MoveCommand()
        };
    }
}