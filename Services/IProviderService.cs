using UserPostApi.Models;

namespace UserPostApi.Services;

public interface IProviderService
{
    Provider? GetProvider(int id);
    IEnumerable<Provider> GetAllProviders();

    void AddProvider(Provider provider);
    void UpdateProvider(Provider provider);
    void DeleteProvider(int id);
}