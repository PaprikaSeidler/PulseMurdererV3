namespace PulseMurdererV3
{
    public class Player
    {
        private int id;
        private string? name;
        private string? avatar;
        private bool isMurderer;

        public Player(){
            Id = id;
            Name = name;
            Avatar = avatar;
            IsMurderer = isMurderer;
        }

        public int Id {
            get => id;
            set{
                id = value;
            }
        }

        public string? Name { 
            get => name;
            set{
                if(value == null){
                    throw new ArgumentNullException("Name cannot be empty");
                }
                if(value.Length < 2){
                    throw new ArgumentException("Name length cannot be lower than 2");
                }
                name = value;
            }
        }

        public string? Avatar { 
            get => avatar;
            set{
                avatar = value;
            }
        }

        public bool IsMurderer { 
            get => isMurderer;
            set{
                isMurderer = value;
            }
        }

        public override string? ToString()
        {
            return $"Id: {Id}, Name: {Name}, Avatar: {Avatar}, IsMurdere: {IsMurderer}";
        }
    }
}
