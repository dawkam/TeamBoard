using System.ComponentModel.DataAnnotations;

namespace TeamBoard.Api.Dtos
{
    public record UpdateBoardRequest([Required, StringLength(50)] string Name, [StringLength(500)] string? Description);
}
