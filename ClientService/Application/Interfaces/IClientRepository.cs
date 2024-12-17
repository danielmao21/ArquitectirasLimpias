using Domain.Entities;

namespace Application.Interfaces;

public interface IClientRepository
{
    Task<Client?> GetByIdAsync(Guid id);
    Task<IEnumerable<Client>> GetAllAsync();
    Task AddAsync(Client client);
    Task UpdateAsync(Client client);
}
