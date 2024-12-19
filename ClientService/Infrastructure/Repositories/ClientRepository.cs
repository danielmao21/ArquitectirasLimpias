using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;
public class ClientRepository : IClientRepository
{
 private readonly ApplicationDbContext _context;
 public ClientRepository(ApplicationDbContext context)
 {
 _context = context;
 }
 public async Task<Client?> GetByIdAsync(Guid id) =>
 await _context.Clients.FindAsync(id);
 public async Task<IEnumerable<Client>> GetAllAsync() =>
 await _context.Clients.ToListAsync();
 public async Task AddAsync(Client client)
 {
 await _context.Clients.AddAsync(client);
 await _context.SaveChangesAsync();
 }
 public async Task UpdateAsync(Client client)
 {
 _context.Clients.Update(client);
 await _context.SaveChangesAsync();
 }
}
