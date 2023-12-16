using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace VbApi.Controllers;

public class Stuff
{
    [Required]
    [StringLength(maximumLength: 250, MinimumLength = 10)]
    public string? Name { get; set; }

    [EmailAddress(ErrorMessage = "Email address is not valid.")]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "Phone is not valid.")]
    public string? Phone { get; set; }

    [Range(minimum: 30, maximum: 400, ErrorMessage = "Hourly salary does not fall within allowed range.")]
    public decimal? HourlySalary { get; set; }
}

[Route("api/[controller]")]
[ApiController]
public class StuffController : ControllerBase
{
    public StuffController()
    {
    }

    [HttpPost]
    public Stuff Post([FromBody] Stuff value)
    {
        return value;
    }
}