using System.ComponentModel.DataAnnotations;

namespace BlazorPizzaDemoApp.Model;

/// <summary>
/// Represents a pre-configured template for a pizza a user can order
/// </summary>
public class PizzaSpecial
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [Range(10.00, 20.00)]
    public decimal BasePrice { get; set; }

    [Required]
    public string Description { get; set; }

    public string ImageUrl { get; set; }

    //FixedSize capability to the pizza model
    public int? FixedSize { get; set; }

    public string GetFormattedBasePrice() => BasePrice.ToString("0.00");
}
