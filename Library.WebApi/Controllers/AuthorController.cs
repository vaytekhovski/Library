using System;
using Library.App.Authors.Queries.GetAuthorList;
using Microsoft.AspNetCore.Mvc;
using Library.App.Authors.Queries.GetAuthorDetails;
using AutoMapper;
using Library.WebApi.Models;
using Library.App.Authors.Commands.CreateAuthor;
using Library.App.Authors.Commands.UpdateAuthor;
using Library.App.Authors.Commands.DeleteAuthor;

namespace Library.WebApi.Controllers
{
	[Route("api/[controller]")]
	public class AuthorController : BaseController
	{
		private readonly IMapper _mapper;

		public AuthorController(IMapper mapper)
		{
			_mapper = mapper;
        }

        [HttpGet]
		public async Task<ActionResult<AuthorListVm>> GetAll()
		{
			var query = new GetAuthorListQuery();
			var vm = await Mediator.Send(query);
			return Ok(vm);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<AuthorDetailVm>> Get(Guid id)
		{
			var query = new GetAuthorDetailQuery
			{
				Id = id
			};
			var vm = await Mediator.Send(query);
			return Ok(vm);
		}

		[HttpPost]
		public async Task<ActionResult<Guid>> Create([FromBody] CreateAuthorDto createAuthorDto)
		{
			var command = _mapper.Map<CreateAuthorCommand>(createAuthorDto);
			var authorId = await Mediator.Send(command);
			return Ok(authorId);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateAuthorDto updateAuthorDto)
		{
			var command = _mapper.Map<UpdateAuthorCommand>(updateAuthorDto);
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var command = new DeleteAuthorCommand
			{
				Id = id
			};
			await Mediator.Send(command);
			return NoContent();
		}
	}
}

