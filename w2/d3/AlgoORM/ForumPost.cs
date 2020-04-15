namespace AlgoORM
{
    public class ForumPost
    {
        public string Topic { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}