using Microsoft.AspNetCore.Mvc;
using TeamBoard.Api.DTOS;
using TeamBoard.Core;

namespace TeamBoard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController(IBoardRepository boards) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<BoardResponse>>> GetBoards(CancellationToken cancellationToken)
        {
            var board = await boards.GetAll(cancellationToken);
            var result = new List<BoardResponse>();
            foreach (var item in board)
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
            var board = await boards.GetById(id, cancellationToken);

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
            var addedBoard = await boards.AddAsync(request.ToEntity(), cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = addedBoard.Id }, addedBoard.ToResponse());
        }
    }
}
