namespace ASP.NET_core_web_api_Milestone_.Models
{
    public class Resolution
    {
        public string Id { get; set; }
        public string TicketId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class Comment
    {
        public string Id { get; set; }
        public string TicketId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
