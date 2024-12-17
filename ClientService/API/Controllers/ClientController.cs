using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly ClientService _clientService;

    public ClientController(ClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<IActionResult> GetClients() =>
        Ok(await _clientService.GetAllClientsAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClient(Guid id)
    {
        var client = await _clientService.GetClientByIdAsync(id);
        return client == null ? NotFound() : Ok(client);
    }

    [HttpPost]
    public async Task<IActionResult> AddClient([FromBody] Client client)
    {
        await _clientService.AddClientAsync(client);
        return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClient(Guid id, [FromBody] Client updatedClient)
    {
        var existingClient = await _clientService.GetClientByIdAsync(id);
        if (existingClient == null)
            return NotFound();

        existingClient.UpdatePersonalInformation(updatedClient.FullName, updatedClient.Address);
        await _clientService.UpdateClientAsync(existingClient);

        return NoContent();
    }
}
