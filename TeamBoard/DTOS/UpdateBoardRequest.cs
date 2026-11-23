using System.ComponentModel.DataAnnotations;

namespace TeamBoard.Api.DTOS
{
    public record UpdateBoardRequest
    {
        [Required, StringLength(50)]
        public string Name { set; get; } = string.Empty;
        public string? Description { set; get; }
    }
}
