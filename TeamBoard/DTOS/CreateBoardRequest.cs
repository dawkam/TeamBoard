using System.ComponentModel.DataAnnotations;

namespace TeamBoard.Api.DTOS
{
    public record CreateBoardRequest([Required, StringLength(50)] string Name, string? Description);
}
