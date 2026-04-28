namespace AIScoutProject.AIScout.Core.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Description { get; set; } = string.Empty; 
    }
}