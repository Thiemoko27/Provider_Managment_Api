using Microsoft.AspNetCore.Mvc;
using UserPostApi.Services;
using UserPostApi.Models;

namespace UserPostApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProviderController : ControllerBase
{
    private readonly IProviderService _providerService;
    private readonly ILogger<ProviderController> _logger;

    public ProviderController(IProviderService providerService, ILogger<ProviderController> logger) {
        _providerService = providerService;
        _logger = logger;
    }

    [HttpGet]

    public ActionResult<IEnumerable<Provider>> GetAllProviders() {
        var providers = _providerService.GetAllProviders();
        return Ok(providers);
    }

    [HttpGet("{id}")]

    public ActionResult<Provider?> GetProvider(int id) {
        var provider =  _providerService.GetProvider(id);

        if(provider == null)
            return NotFound();

        return Ok(provider);
    }

    [HttpPost]

    public ActionResult<Provider> PostUser(Provider provider) {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try {
            _providerService.AddProvider(provider);
            return CreatedAtAction(nameof(GetProvider), new {id = provider.Id}, provider);
        } catch(Exception ex) {
            _logger.LogError($"Failed to add provider : {ex.Message}", ex);

            if(ex.InnerException != null) {
                _logger.LogError($"Inner Exception: {ex.InnerException.Message}", ex.InnerException);
            }
                return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPut("{id}")]

    public IActionResult PutUser(int id, [FromBody] Provider provider) {
        if(id != provider.Id) {
            Console.WriteLine("fdjbfdun");
            return BadRequest("L'id ne correspond pas");
        }

        if(!ModelState.IsValid) {
            Console.WriteLine("ssssbfdun");
            return BadRequest(ModelState);
        }
            
        try {
            _providerService.UpdateProvider(provider);
            return NoContent();
        } catch(Exception) {
            return StatusCode(500, "Internal error");
        }
    }

    [HttpDelete("{id}")]

    public IActionResult DeleteProvider(int id) {
        _providerService.DeleteProvider(id);

        return NoContent();
    }
}