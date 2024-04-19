namespace Library.Convos.Models
{
    public class Assignment
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int TotalAvailablePoints { get; set; }
        public DateTime DueDate { get; set; }

        public List<AssignmentSubmission> SubmittedAssignments { get; set; }

        public Assignment()
        {
            if (SubmittedAssignments == null) SubmittedAssignments = new List<AssignmentSubmission>();
        }
    }
}