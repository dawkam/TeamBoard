using System.ComponentModel.DataAnnotations;

namespace TeamBoard.Api.Dtos
{
    public record CreateBoardRequest([Required, StringLength(50)] string Name, [StringLength(500)] string? Description);
}
