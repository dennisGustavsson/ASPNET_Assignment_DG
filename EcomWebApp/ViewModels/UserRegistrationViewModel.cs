using System.ComponentModel.DataAnnotations;

namespace EcomWebApp.ViewModels;

public class UserRegistrationViewModel
{
    [Display(Name = "First Name")]
    [Required(ErrorMessage = "You must enter a first name.")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "You must enter a last name.")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Street Name")]
    [Required(ErrorMessage = "You must enter a street name.")]
    public string StreetName { get; set; } = null!;

    [Display(Name = "Postal Code")]
    [Required(ErrorMessage = "You must enter a postal code.")]
    public string PostalCode { get; set; } = null!;

    [Display(Name = "City")]
    [Required(ErrorMessage = "You must enter a city.")]
    public string City { get; set; } = null!;

    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Company Name")]
    public string? CompanyName { get; set; }

    [Display(Name = "E-mail")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "You must enter an email.")]
    [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$",
        ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "You must enter a password.")]
    [RegularExpression(@"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).*$",
        ErrorMessage = "Password must be at least 8 characters long and contain at least one lowercase letter, one uppercase letter, one digit, and one special character.")]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "You need to confirm your password.")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "Uplad Profile Picture")]
    [DataType(DataType.Upload)]
    public IFormFile? ProfileImage { get; set; }

    [Display(Name = "I have read and accepts the terms and agreement")]
    [Required(ErrorMessage = "You need to accept the terms and agreement.")]
    public bool TermsAndAgreement { get; set; } = false;


}
