using LeadersCorner.Data;
using LeadersCorner.Data.Models;
using LeadersCorner.Web.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadersCorner.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly LeadersCornerDbContext data;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            LeadersCornerDbContext data
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.data = data;
        }

        public string Username { get; set; }

        [Display(Name = "First Name")]
        public string UserFirstName { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Last Name")]
        public string UserLastName { get; set; }

        [Display(Name = "Profession")]
        public string Profession { get; internal set; }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await this.userManager.GetUserNameAsync(user);
            var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);

            this.Username = userName;
            this.UserFirstName = user.UserFirstName;
            this.UserLastName = user.UserLastName;
            this.Profession = user.Profession;
            this.PhoneNumber = user.PhoneNumber;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await this.userManager.GetUserAsync(User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(User)}'.");
            }

            await this.LoadAsync(user);
            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync(string userFirstName, string userLastName, string phoneNumber, string profession)
        {
            var user = await this.userManager.GetUserAsync(User);
            
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(User)}'.");
            }

            if (!this.ModelState.IsValid)
            {
                await this.LoadAsync(user);
                
                return this.Page();
            }

            if (this.ModelState.IsValid)
            {
              if(  await TryUpdateModelAsync<ApplicationUser>(
                    user,
                    "",
                    c=> c.UserFirstName, c=>c.UserLastName, c=>c.Profession, c => c.PhoneNumber))
                {
                    user.UserFirstName = userFirstName;
                    user.UserLastName = userLastName;
                    user.Profession = profession;
                    user.PhoneNumber = phoneNumber;

                }
                await this.data.SaveChangesAsync();
            }
           // var setPhoneResult = await this.userManager.SetPhoneNumberAsync(user, this.PhoneNumber);
          
           
            //var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);
            //if (Input.PhoneNumber != phoneNumber)
            //{
            //    var setPhoneResult = await this.userManager.SetPhoneNumberAsync(user, this.Input.PhoneNumber);
            //    if (!setPhoneResult.Succeeded)
            //    {
            //        this.StatusMessage = "Unexpected error when trying to set data.";
            //        return this.RedirectToPage();
            //    }
            //}

            //if (this.Input.UserLastName == user.UserLastName || this.Input.UserLastName != "")
            //{
            //    this.StatusMessage = "Unexpected error when trying to set phone number.";
            //    return this.RedirectToPage();
            //}
            //else
            //{
            //    user.UserLastName = this.Input.UserLastName;
            //}
            //if (this.Input.Profession == user.Profession || this.Input.UserLastName != "")
            //{
            //    this.StatusMessage = "Unexpected error when trying to set phone number.";
            //    return this.RedirectToPage();
            //}
            //else
            //{
            //    user.Profession = this.Input.Profession;
            //}

            await this.signInManager.RefreshSignInAsync(user);
            this.StatusMessage = "Your profile has been updated";
            return this.RedirectToPage();
        }
    }
}
