using System;
namespace Library.App.Interfaces
{
	public class MongoDBSettings : IMongoDBSettings
	{
		public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string AuthorsCollectionName { get; set; } = string.Empty;
        public string BooksCollectionName { get; set; } = string.Empty;
    }
}

