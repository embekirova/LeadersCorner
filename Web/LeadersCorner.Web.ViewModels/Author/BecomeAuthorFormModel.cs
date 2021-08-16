namespace LeadersCorner.Web.ViewModels.Author
{
    using System.ComponentModel.DataAnnotations;

    using LeadersCorner.Data.Common;

    public class BecomeAuthorFormModel
    {
        [Required(ErrorMessage = "The field is required")]
        [MinLength(DataConstants.Author.NameMin, ErrorMessage = "First Name should be more than 3 symbols")]
        [MaxLength(DataConstants.Author.NameMax, ErrorMessage = "First Name should be less than 25 symbols")]
        
        [Display(Name = "First Name")]
        
        public string FirstName { get; set; }

        [Required]
        [MinLength(DataConstants.Author.NameMin, ErrorMessage = "First Name should be more than 3 symbols")]
        [MaxLength(DataConstants.Author.NameMax, ErrorMessage = "First Name should be less than 25 symbols")]
        [Display(Name = "Last Name")]
        [Compare("LastName", ErrorMessage = "Your last name should be between 3 and 25 symbols")]
        public string LastName { get; set; }
    }
}
