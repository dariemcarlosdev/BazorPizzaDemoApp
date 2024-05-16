﻿using System.ComponentModel.DataAnnotations;

namespace BlazingPizzaNavigation.Model;


public class Address
{
    public int Id { get; set; }
    [Required(ErrorMessage = "You must set a name."), MinLength(3), MaxLength(100)]
    public string Name { get; set; }
    [Required(ErrorMessage = "You must set your address."), MinLength(5), MaxLength(100)]
    public string Line1 { get; set; }
    [MaxLength(100)]
    public string Line2 { get; set; }

    public string City { get; set; }
    [Required, MinLength(3), MaxLength(20)]
    public string Region { get; set; }
    [Required, RegularExpression(@"^([0-9]{5})$")]
    //custom data annotation validator attribute.
    //[PostalCodeAttribute]
    public string PostalCode { get; set; }
}

