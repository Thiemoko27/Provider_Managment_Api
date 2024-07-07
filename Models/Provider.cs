using System.ComponentModel.DataAnnotations;

namespace UserPostApi.Models;

public class Provider
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Store number required")]
    public int StoreNumber { get; set; }

    [Required(ErrorMessage = "Store name required")]
    public string? StoreName { get; set; }

    [Required(ErrorMessage = "Store location required")]
    public string? Location { get; set; }

    [Required(ErrorMessage = "Password Required")]
    public string? Password { get; set; }
}