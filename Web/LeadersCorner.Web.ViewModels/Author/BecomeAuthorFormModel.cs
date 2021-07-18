namespace LeadersCorner.Web.ViewModels.Author
{
    using System.ComponentModel.DataAnnotations;

    using LeadersCorner.Data.Common;

    public class CreateArticleFormModel
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
