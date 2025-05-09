using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseMurdererV3
{
    public class PlayerRepository
    {
        private List<Player> players = new List<Player>();
        private int _nextId = 1;

        public PlayerRepository(){
            this.AddPlayer(new Player() {Name = "Miki", IsMurderer = false});
            this.AddPlayer(new Player() {Name = "Pap", IsMurderer = false});
            this.AddPlayer(new Player() {Name = "Jais", IsMurderer = false});
            this.AddPlayer(new Player() {Name = "Peter", IsMurderer = true});
            this.AddPlayer(new Player() {Name = "Morten", IsMurderer = false});
        }

        public List<Player>? GetAllPlayers()
        {
            var playerList = new List<Player>(players);
            return playerList;
        }

        public Player? AddPlayer(Player player) {
            if(player == null){
                throw new ArgumentNullException("Player cannot be null");
            }

            player.Id = _nextId++;
            players.Add(player);
            return player;
        }
        public Player UpdatePlayer(Player player)
        {
            var existingPlayer = players.FirstOrDefault(p => p.Id == player.Id);
            if (existingPlayer != null)
            {
                existingPlayer.IsMurderer = player.IsMurderer;
                return existingPlayer;
            }
            else
            {
                throw new Exception("Player not found");
            }

        }
    }
}
