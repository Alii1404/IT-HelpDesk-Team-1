namespace ITHelpDesk
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; } = "New";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }
    }
}
