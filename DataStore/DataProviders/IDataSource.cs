using DataStore.Models;

namespace DataStore.DataProviders
{
    public interface IDataSource
    {
        SourceData ImportData(string fileName);
    }
}
