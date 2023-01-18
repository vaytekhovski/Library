using System;
using Library.App.Common;
using Library.App.Interfaces;
using Library.Persistence;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Library.Persistence
{
    public class MongoDBService : IMongoDBService
    {
        public IMongoCollection<Author> _authors { get; set; }
        public IMongoCollection<Book> _books { get; set; }

        public MongoDBService(IMongoDBSettings settings, IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(settings.DatabaseName);
            _authors = database.GetCollection<Author>(settings.AuthorsCollectionName);
            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public async Task CreateAuthorAsync(Author author)
        {
            await _authors.InsertOneAsync(author);
            return;
        }

        public async Task<List<Author>> GetAuthorsAsync()
        {
            return await _authors.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Author> GetAuthorAsync(ObjectId id)
        {
            //return await _authors.Find()
            throw new NotImplementedException();
        }

        public Task DeleteAuthorAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task CreateBookAsync(ObjectId authorId, Book book)
        {
            //FilterDefinition<Author>
            throw new NotImplementedException();
        }

        public Task<Book> GetBookAsync(ObjectId bookId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetBooksAsync(ObjectId authorId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBookAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }
    }
}

