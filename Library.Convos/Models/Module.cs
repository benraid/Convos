namespace Library.Convos.Models
{
    public class Module
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<ContentObject> Content { get; set; }

        public Module() 
        {
            Content = new List<ContentObject>();
        }

        public override string ToString()
        {
            return $"[{Name}] - {Description}";
        }
    }
}