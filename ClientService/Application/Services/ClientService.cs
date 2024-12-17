using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;
public class ClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<IEnumerable<Client>> GetAllClientsAsync() => await _clientRepository.GetAllAsync();

    public async Task<Client?> GetClientByIdAsync(Guid id) => await _clientRepository.GetByIdAsync(id);

    public async Task AddClientAsync(Client client) => await _clientRepository.AddAsync(client);
    public async Task UpdateClientAsync(Client client) => await _clientRepository.UpdateAsync(client);
}
