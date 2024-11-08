using FluentValidation;

namespace HuquqApi.Dtos.UserDtos
{
    public class ResetPasswordDto
    {
        public string  Password{ get; set; }
        public string RePassword { get; set; }

    }
    public class ResetPasswordDtoValidator : AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordDtoValidator() 
        {

            RuleFor(r => r.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(30);


            RuleFor(r => r.RePassword)
               .NotEmpty()
               .MinimumLength(6)
               .MaximumLength(30);


            RuleFor(r => r.Password)
                .Custom((password, context) =>
                {
                    var rePassword = context.InstanceToValidate.RePassword;

                    if (password != rePassword)
                    {
                        context.AddFailure("Password", "Password and confirmation password do not match.");
                    }
                });

        }
    }
}
