using System.ComponentModel.DataAnnotations;

namespace TeamBoard.Api.DTOS
{
    public record UpdateBoardRequest([Required, StringLength(50)] string Name, [StringLength(500)] string? Description);
}
