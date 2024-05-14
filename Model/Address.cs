using System.ComponentModel.DataAnnotations;

namespace BlazingPizzaNavigation.Model;


public class Address
{
    public int Id { get; set; }
    [Required(ErrorMessage = "You must set a name.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "You must set your address.")]
    public string Line1 { get; set; }

    public string Line2 { get; set; }

    public string City { get; set; }

    public string Region { get; set; }

    [PostalCodeAttribute]
    public string PostalCode { get; set; }
}

