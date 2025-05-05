namespace PulseMurdererV3
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public bool IsMurderer { get; set; }


        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Avatar: {Avatar}, IsMurderer: {IsMurderer}";
        }
    }
}
