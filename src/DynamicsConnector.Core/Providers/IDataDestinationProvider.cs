using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicsConnector.Core.Providers
{
    public interface IDataDestinationProvider
    {
        Task PostDataAsync<T>(List<T> data, params string[] parameters);
        Task PostDataAsync<T>(T dataItem, params string[] parameters);
    }
}
