namespace TeamBoard.Api.Dtos
{
    public record BoardResponse(Guid Id, string Name, string? Description, DateTimeOffset CreatedAt);
}
