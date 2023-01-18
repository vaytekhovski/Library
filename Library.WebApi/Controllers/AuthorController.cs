using System;
using Library.App.Authors.Queries.GetAuthorList;
using Microsoft.AspNetCore.Mvc;
using Library.App.Authors.Queries.GetAuthorDetails;
using AutoMapper;
using Library.WebApi.Models;
using Library.App.Authors.Commands.CreateAuthor;
using Library.App.Authors.Commands.UpdateAuthor;
using Library.App.Authors.Commands.DeleteAuthor;
using MediatR;
using MongoDB.Bson;

namespace Library.WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	public class AuthorController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public AuthorController(IMapper mapper, IMediator mediator) => (_mapper, _mediator) = (mapper, mediator);

        [HttpGet]
		public async Task<ActionResult<AuthorListVm>> GetAll()
		{
			var vm = await _mediator.Send(new GetAuthorListQuery());
			return Ok(vm);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<AuthorDetailVm>> Get(ObjectId id)
		{
			var vm = await _mediator.Send(new GetAuthorDetailQuery
            {
                Id = id
            });
			return Ok(vm);
		}

		[HttpPost]
		public async Task<ActionResult<ObjectId>> Create([FromBody] CreateAuthorDto createAuthorDto)
		{
			var command = _mapper.Map<CreateAuthorCommand>(createAuthorDto);
			var authorId = await _mediator.Send(command);
			return Ok(authorId);
		}

        [HttpPost]
        public async Task<ActionResult<string>> Create()
        {
            return Ok("it works");
        }

        [HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateAuthorDto updateAuthorDto)
		{
			var command = _mapper.Map<UpdateAuthorCommand>(updateAuthorDto);
			await _mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(ObjectId id)
		{
			await _mediator.Send(new DeleteAuthorCommand
            {
                Id = id
            });
			return NoContent();
		}
	}
}

