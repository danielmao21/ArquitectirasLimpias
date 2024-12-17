using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repositories;
public class ClientRepository : IClientRepository
{
    private readonly List<Client> _clients = new();

    public Task<Client?> GetByIdAsync(Guid id) =>
        Task.FromResult(_clients.SingleOrDefault(c => c.Id == id));

    public Task<IEnumerable<Client>> GetAllAsync() =>
        Task.FromResult(_clients.AsEnumerable());

    public Task AddAsync(Client client)
    {
        _clients.Add(client);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Client client)
    {
        var index = _clients.FindIndex(c => c.Id == client.Id);
        if (index >= 0)
            _clients[index] = client;

        return Task.CompletedTask;
    }
}
