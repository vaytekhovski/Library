using System;
using Library.App.Interfaces;
using Library.App.Common;
using MediatR;
using MongoDB.Bson;

namespace Library.App.Authors.Commands.CreateAuthor
{
	public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, ObjectId?>
	{
        private readonly IMongoDBService _dbService;

        public CreateAuthorCommandHandler(IMongoDBService dbContext) => _dbService = dbContext;

        public async Task<ObjectId?> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author()
            {
                FullName = request.FullName,
                Biography = request.Biography,
                DateOfBirth = request.DateOfBirth,
                DateOfDeath = request.DateOfDeath
            };

            await _dbService.CreateAuthorAsync(author);

            return author.Id;
        }
    }
}

