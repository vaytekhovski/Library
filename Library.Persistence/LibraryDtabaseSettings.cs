using System;
namespace Library.Persistence
{
	public class LibraryDtabaseSettings : ILibraryDatabaseSetting
	{
        public string AuthorsCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}

