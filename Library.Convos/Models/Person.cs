namespace Library.Convos.Models
{
    public class Person
    {
        public int Id { get; set; } // FIX ME: Replace with GUID eventually
        public string Name { get; set; }
        public string? Classification { get; set; }
        public Dictionary<string, double> Grades { get; set; }
        public Person() 
        {
            Grades = new Dictionary<string, double>();
            Name = string.Empty;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {Classification}";
        }
    }
}