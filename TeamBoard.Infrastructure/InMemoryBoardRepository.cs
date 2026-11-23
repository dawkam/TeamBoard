using System.Collections.Concurrent;
using TeamBoard.Core;
using TeamBoard.Core.Entities;

namespace TeamBoard.Infrastructure
{
    public class InMemoryBoardRepository(TimeProvider timeProvider) : IBoardRepository
    {
        private readonly ConcurrentDictionary<Guid, Board> _boards = [];

        public Task<Board> AddAsync(string name, string? description, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var newBoard = new Board
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                CreatedAt = timeProvider.GetUtcNow()

            };
            return Task.FromResult(newBoard);
        }

        public Task<IReadOnlyList<Board>> GetAllAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult<IReadOnlyList<Board>>(_boards.Values.ToList().AsReadOnly());
        }

        public Task<Board?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _boards.TryGetValue(id, out var board);
            return Task.FromResult(board);
        }

        public Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(_boards.TryRemove(id, out var _));
        }

        public Task<bool> UpdateAsync(Board board, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (!_boards.TryGetValue(board.Id, out var existing) ||
                    !_boards.TryUpdate(board.Id, board, existing))
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(true);
        }
    }
}
