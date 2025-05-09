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

        public Player? AddPlayer(Player? player) {
            if(player == null){
                throw new ArgumentNullException("Player cannot be null");
            }

            player.Id = _nextId++;
            players.Add(player);
            return player;
        }

        public Player? GetPlayerById(int id){
            int left = 0;
            int right = players.Count - 1;

            while(left <= right){
                int mid = left + (right - left) / 2;

                if(players[mid].Id == id){
                    return players[mid];
                }
                else if(players[mid].Id < id){
                    left = mid + 1;
                }
                else{
                    right = mid - 1;
                }
            }

            return null;
        }

        public Player? UpdatePlayer(int id, Player? newValues) {
            Player? existingPlayer = this.GetPlayerById(id);
            if(existingPlayer == null){
                throw new ArgumentNullException("Player not found");
            }

            existingPlayer.IsMurderer = newValues.IsMurderer;
            return existingPlayer;
        }
    }
}
