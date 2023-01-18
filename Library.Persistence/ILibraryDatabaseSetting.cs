using System;
namespace Library.Persistence
{
	public interface ILibraryDatabaseSetting
    {
		public string AuthorsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

