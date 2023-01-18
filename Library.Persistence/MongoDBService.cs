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

        public async Task<Author> GetAuthorAsync(string id)
        {
            return await _authors.Find(author => author.Id == id).FirstOrDefaultAsync();
        }

        public async Task DeleteAuthorAsync(string id)
        {
            await _authors.DeleteOneAsync(author => author.Id == id);
        }

        public async Task UpdateAuthorAsync(string authorId, Author author)
        {
            await _authors.ReplaceOneAsync(author => author.Id == authorId, author);
        }

        public Task CreateBookAsync(string authorId, Book book)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookAsync(string bookId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetBooksAsync(string authorId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBookAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBookAsync(string bookId, Book book)
        {
            throw new NotImplementedException();
        }
    }
}

