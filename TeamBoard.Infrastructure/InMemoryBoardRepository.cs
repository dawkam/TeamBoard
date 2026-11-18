using System.Collections.Concurrent;
using TeamBoard.Core;
using TeamBoard.Core.Entities;

namespace TeamBoard.Infrastructure
{
    internal class InMemoryBoardRepository : IBoardRepository
    {
        private readonly ConcurrentDictionary<Guid, Board> BoardCollection = [];

        public Task AddBoard(Board board, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (!BoardCollection.TryAdd(board.Id, board))
            {
                throw new ArgumentException($"There is already record with guid: {board.Id}");
            }
            return Task.CompletedTask;
        }

        public Task<IReadOnlyList<Board>> GetAll(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult<IReadOnlyList<Board>>(BoardCollection.Values.ToList().AsReadOnly());
        }

        public Task<Board> GetBoard(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (!BoardCollection.TryGetValue(id, out var board))
            {
                throw new KeyNotFoundException($"Missing record with {id} ");
            }
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
