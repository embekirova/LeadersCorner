namespace LeadersCorner.Web.ViewModels.Author
{
    using LeadersCorner.Data.Common;
    using System.ComponentModel.DataAnnotations;

    public class BecomeAuthorFormModel
    {

        [Required]
        [MinLength(DataConstants.Author.NameMin)]
        [MaxLength(DataConstants.Author.NameMax)]
        [Display(Name = "First Name")]
        [Compare("FirstName", ErrorMessage = "Your first name should be between 3 and 25 symbols")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(DataConstants.Author.NameMin)]
        [MaxLength(DataConstants.Author.NameMax)]
        [Display(Name = "Last Name")]
        [Compare("LastName", ErrorMessage = "Your last name should be between 3 and 25 symbols")]
        public string LastName { get; set; }

    }
}
