using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompileTimeReflection.Test.TestData;

[DefaultProperty(nameof(Contact.ContactNumber))]
public class Contact
{
    [Key]
    public Guid IdContact { get; set; }

    [DisplayName("Contact Id:")]
    [Required]
    public long ContactNumber { get; set; }

    [DisplayName("First name:")]
    [Required]
    public string? FirstName { get; set; }

    [DisplayName("Last name:")]
    [Required]
    public string? LastName { get; set; }

    [DisplayName("Date of birth:")]
    public DateTime? DateOfBirth { get; set; }
}
