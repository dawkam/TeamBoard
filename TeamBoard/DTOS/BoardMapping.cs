using TeamBoard.Core.Entities;

namespace TeamBoard.Api.DTOS
{
    public static class BoardMapping
    {

        public static BoardResponse ToResponse(this Board board)
        {
            return new BoardResponse()
            {
                Name = board.Name,
                Description = board.Description
            };
        }

        public static Board ToEntity(this CreateBoardRequest createBoardRequest)
        {
            return new Board()
            {
                Id = Guid.NewGuid(),
                Name = createBoardRequest.Name,
                Description = createBoardRequest.Description ?? "",
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
