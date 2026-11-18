using System.ComponentModel.DataAnnotations;

namespace TeamBoard.Api.DTOS
{
    public record BoardResponse
    {
        [Required, StringLength(10)]
        public Guid Id { set; get; }

        [Required, StringLength(50)]
        public string Name { set; get; } = string.Empty;
        public string? Description { set; get; }
        [Required]
        public DateTimeOffset CreatedAt { set; get; }
    }
}
