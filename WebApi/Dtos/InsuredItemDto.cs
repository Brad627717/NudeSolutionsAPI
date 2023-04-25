namespace WebApi.Dtos
{
    public class InsuredItemDto
    {
        public int Id { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public double Value { get; set; }
        public int CategoryId { get; set; }
    }
}
