namespace TeamBoard.Core.Entities
{
    public class Board
    {
        public int Id { set; get; }
        public string Name { set; get; } = string.Empty;
        public string Description { set; get; } = string.Empty;
        public DateTimeOffset CreatedAt { set; get; }
    }
}
