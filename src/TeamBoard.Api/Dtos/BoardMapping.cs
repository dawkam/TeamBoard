using TeamBoard.Core.Entities;

namespace TeamBoard.Api.Dtos
{
    public static class BoardMapping
    {

        public static BoardResponse ToResponse(this Board board)
        {
            return new BoardResponse(Id: board.Id,
                Name: board.Name,
                Description: board.Description,
                CreatedAt: board.CreatedAt)
            ;
        }
    }
}
