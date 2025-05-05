using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseMurdererV3
{
    public class PlayerRepository
    {
        private List<Player> players = new();

        public PlayerRepository(){
            players.Add(new Player() {Name = "Miki", IsMurderer = false});
            players.Add(new Player() {Name = "Pap", IsMurderer = false});
            players.Add(new Player() {Name = "Jais", IsMurderer = false});
            players.Add(new Player() {Name = "Peter", IsMurderer = true});
            players.Add(new Player() {Name = "Morten", IsMurderer = false});
        }

        public List<Player> GetAllPlayers()
        {
            return new List<Player>(players);
        }
    }
}
