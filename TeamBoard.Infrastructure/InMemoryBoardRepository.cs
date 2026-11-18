using System.Collections.Concurrent;
using TeamBoard.Core;
using TeamBoard.Core.Entities;

namespace TeamBoard.Infrastructure
{
    public class InMemoryBoardRepository : IBoardRepository
    {
        private readonly ConcurrentDictionary<Guid, Board> BoardCollection = [];

        public Task<Board> AddAsync(Board board, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (!BoardCollection.TryAdd(board.Id, board))
            {
                throw new ArgumentException($"There is already record with guid: {board.Id}");
            }
            return Task.FromResult(board);
        }

        public Task<IReadOnlyList<Board>> GetAll(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult<IReadOnlyList<Board>>(BoardCollection.Values.ToList().AsReadOnly());
        }

        public Task<Board?> GetById(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            BoardCollection.TryGetValue(id, out var board);
            return Task.FromResult(board);
        }

        public Task RemoveBoard(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            BoardCollection.TryRemove(id, out var _);
            return Task.CompletedTask;
        }

        public Task UpdateBoard(Board board, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (!BoardCollection.TryGetValue(board.Id, out var existing) ||
                    !BoardCollection.TryUpdate(board.Id, board, existing))
            {
                throw new KeyNotFoundException($"Failed update on {board.Id}");
            }
            return Task.CompletedTask;
        }
    }
}
