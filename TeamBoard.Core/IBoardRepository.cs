using TeamBoard.Core.Entities;

namespace TeamBoard.Core
{
    public interface IBoardRepository
    {
        public Task<IReadOnlyList<Board>> GetAllAsync(CancellationToken cancellationToken);

        public Task<Board?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        public Task<Board> AddAsync(string name, string? description, CancellationToken cancellationToken);

        public Task<bool> UpdateAsync(Board board, CancellationToken cancellationToken);

        public Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken);
    }
}
