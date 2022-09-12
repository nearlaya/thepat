using System;

namespace DataStore.DataProviders
{
    public static class DataSourceFabric
    {
        // just a simplified factory-method to get the data providers you need

        public static IDataSource GetDataSourceByFileType(string fileType)
        {
            if (fileType is null)
            {
                throw new ArgumentNullException(nameof(fileType));
            }

            if (fileType == string.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(fileType));
            }

            Type dataSourceType = null;

            if (fileType.Equals(Constants.FileExtensions.EXTENSION_CSV, StringComparison.OrdinalIgnoreCase))
            {
                dataSourceType = typeof(PlainDataSource);
            }

            if (dataSourceType == null)
            {
                return null;
            }

            return Activator.CreateInstance(dataSourceType) as IDataSource;
        }
    }
}
