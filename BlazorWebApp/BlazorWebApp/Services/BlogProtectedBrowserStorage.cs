using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using SharedComponents.Interfaces;

namespace BlazorWebApp.Services;

public class BlogProtectedBrowserStorage : IBrowserStorage
{
    ProtectedSessionStorage Storage { get; set; }

    public BlogProtectedBrowserStorage(ProtectedSessionStorage storage)
    {
        Storage = storage;
    }

    public async Task DeleteAsync(string key)
    {
        await Storage.DeleteAsync(key);
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var value = await Storage.GetAsync<T>(key);
        return value.Success ? value.Value : default(T);
    }

    public async Task SetAsync(string key, object value)
    {
        await Storage.SetAsync(key, value);
    }
}