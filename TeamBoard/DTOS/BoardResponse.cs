namespace TeamBoard.Api.DTOS
{
    public record BoardResponse(Guid Id, string Name, string? Description, DateTimeOffset CreatedAt)
    { }
}
