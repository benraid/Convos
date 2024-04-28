namespace Library.Convos.Models
{
    public class AssignmentSubmission
    {
        public int StudentId { get; set; } // TODO: Replace with GUID eventually
        public string? StudentName { get; set; }
        public string? Title { get; set; }
        public string? Answer { get; set; }
        public int Grade { get; set; }
    }
}

