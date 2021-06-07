using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersManagerLib
{
    public class Player
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Country { get; private set; }
        public int NoofMatches { get; private set; }

        public Player(string name, int age, string country, int noofMatches)
        {
            Name = name;
            Age = age;
            Country = country;
            NoofMatches = noofMatches;
        }

        public static Player RegisterNewPlayer(string name, IPlayerMapper playerMapper = null)
        {
            if (playerMapper == null)
            {
                playerMapper = new PlayerMapper();
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("player name already exists.");
            }

            playerMapper.AddNewPlayerIntoDb(name);

            return new Player(name, 23, "India", 30);
        }

    }
}


