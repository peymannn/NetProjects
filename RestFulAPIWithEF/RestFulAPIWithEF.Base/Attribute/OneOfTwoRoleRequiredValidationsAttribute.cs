using System.ComponentModel.DataAnnotations;

namespace RestFulAPIWithEF.Base
{
    public class OneOfTwoRoleRequiredValidationsAttribute : ValidationAttribute
    {
        public OneOfTwoRoleRequiredValidationsAttribute(bool junior, bool senior)
        {
            Junior = junior;
            Senior = senior;
        }
        public bool Junior { get; set; }
        public bool Senior { get; set; }
        public string GetErrorMessage() => $"junior/senior write please";

        protected override ValidationResult IsValid(Object value, ValidationContext validationContext)
        {
            bool result = false;

            if (Junior && Senior)
            {
                result = value.ToString() == "junior" || value.ToString() == "senior";
            }
            else if (Junior)
            {
                result = value.ToString() == "junior";
            }
            else if (Senior)
            {
                result = value.ToString() == "senior";
            }

            return result ? ValidationResult.Success : new ValidationResult(GetErrorMessage());

        }
    }
}
