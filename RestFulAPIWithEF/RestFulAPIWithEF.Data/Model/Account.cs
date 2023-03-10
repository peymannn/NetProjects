using RestFulAPIWithEF.Base;
using System.ComponentModel.DataAnnotations;

namespace RestFulAPIWithEF.Data.Model
{
    public class Account : BaseModel
    {
        [StringLength(maximumLength: 50 )]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "hey email")]
        public string Email { get; set; }

        [OneOfTwoRoleRequiredValidationsAttribute(junior: true, senior: false)]
        public string Role { get; set; }
        public DateTime LastActivity { get; set; }
    }
}
