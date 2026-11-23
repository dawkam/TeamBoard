using Microsoft.AspNetCore.Mvc;
using TeamBoard.Api.Dtos;
using TeamBoard.Core;

namespace TeamBoard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController(IBoardRepository repository) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<BoardResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var boards = await repository.GetAllAsync(cancellationToken);
            var result = new List<BoardResponse>();
            foreach (var item in boards)
            {
                result.Add(item.ToResponse());
            }
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BoardResponse>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var board = await repository.GetByIdAsync(id, cancellationToken);

            if (board is null)
            {
                return NotFound();
            }

            return Ok(board.ToResponse());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BoardResponse>> Create(CreateBoardRequest request, CancellationToken cancellationToken)
        {
            var addedBoard = await repository.AddAsync(request.Name, request.Description, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = addedBoard.Id }, addedBoard.ToResponse());
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(Guid id, UpdateBoardRequest request, CancellationToken cancellationToken)
        {
            var board = await repository.GetByIdAsync(id, cancellationToken);
            if (board is null)
            {
                return NotFound();
            }
            board.Name = request.Name;
            board.Description = request.Description;
            if (!await repository.UpdateAsync(board, cancellationToken))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            if (!await repository.DeleteAsync(id, cancellationToken))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
