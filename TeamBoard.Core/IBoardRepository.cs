using TeamBoard.Core.Entities;

namespace TeamBoard.Core
{
    public interface IBoardRepository
    {
        Task<IReadOnlyList<Board>> GetAllAsync(CancellationToken cancellationToken);

        Task<Board?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<Board> AddAsync(string name, string? description, CancellationToken cancellationToken);

        Task<bool> UpdateAsync(Board board, CancellationToken cancellationToken);

        Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken);
    }
}
