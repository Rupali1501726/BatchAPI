namespace BatchAPI.Entities
{
    public class BatchResponse
    {
        public string? CorrelationID { get; set; }
        public Errors? Errors { get; set; }
    }
    public class Errors
    {
        public string Source { get; set; }
        public string Description { get; set; }
    }
}
