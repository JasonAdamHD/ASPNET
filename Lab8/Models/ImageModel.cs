using System.ComponentModel.DataAnnotations;

namespace Lab8.Models;

public class ImageModel
{
    [Required]
    public IFormFile? file { get; set; }

    [Required]
    public string description { get; set; } = "";
}
