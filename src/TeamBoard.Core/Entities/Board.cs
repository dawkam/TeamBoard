namespace TeamBoard.Core.Entities
{
    public class Board
    {
        public Guid Id { set; get; }
        public string Name { set; get; } = string.Empty;
        public string? Description { set; get; }

        public DateTimeOffset CreatedAt { set; get; }
    }
}
