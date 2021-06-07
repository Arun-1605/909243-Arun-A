using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PlayersManagerLib;

namespace PlayerManager.Tests
{
    [TestFixture]
    public class PlayerManager_should
    {
        [Test]
        [TestCase("Arun")]
        public void check_RegisterNewPlayer1(string name)
        {
            Mock<IPlayerMapper> iplayerMappermock = new Mock<IPlayerMapper>();

            iplayerMappermock.Setup(x => x.AddNewPlayerIntoDb(It.IsAny<string>()));
            var player =   Player.RegisterNewPlayer(name, iplayerMappermock.Object);
            
            Assert.That(player.Name== name);
        }

        [Test]
        [TestCase("Arun")]
        public void check_RegisterNewPlayer(string name)
        {
            Mock<IPlayerMapper> iplayerMappermock = new Mock<IPlayerMapper>();
            
            iplayerMappermock.Setup(x => x.IsPlayerNameExistsInDb(It.IsAny<string>())).Returns(true);
            var player =  Player.RegisterNewPlayer(name,iplayerMappermock.Object);

            Assert.AreEqual(name, player.Name);

       }


    }
}
