namespace MinhasNotas.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public char Shift { get; set; }
        public int Room { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}

