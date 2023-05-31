namespace BatchAPI.Entities
{
    public class BatchRequest //change name
    {
        public string? BusinessUnit { get; set; }
        public string? ExpiryDate { get; set; }
        public string? ReadUsers { get; set; }
        public string? ReadGroups { get; set; }
        public string? KeyAttribute { get; set; }
        public string? ValueAttribute { get; set; }
        public string? Status { get; set; }
    }
}
