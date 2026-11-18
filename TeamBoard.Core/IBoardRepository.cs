using TeamBoard.Core.Entities;

namespace TeamBoard.Core
{
    public interface IBoardRepository
    {
        public Task<IReadOnlyList<Board>> GetAll(CancellationToken cancellationToken);

        public Task<Board> GetBoard(int id, CancellationToken cancellationToken);

        public Task AddBoard(Board board, CancellationToken cancellationToken);

        public Task UpdateBoard(Board board, CancellationToken cancellationToken);

        public Task RemoveBoard(int id, CancellationToken cancellationToken);
    }
}
