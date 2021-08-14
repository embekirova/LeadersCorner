namespace LeadersCorner.Web.ViewModels.Author
{
    using LeadersCorner.Data.Common;
    using System.ComponentModel.DataAnnotations;

    public class AllAuthorsFormView
    {

        [Required]
        [MinLength(DataConstants.Author.NameMin)]
        [MaxLength(DataConstants.Author.NameMax)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(DataConstants.Author.NameMin)]
        [MaxLength(DataConstants.Author.NameMax)]
        public string LastName { get; set; }

    }
}
