using BatchAPI.Entities;
using FluentValidation;

namespace BatchAPI.Validator
{
    public class Batchvalidator : AbstractValidator<BatchRequest>
    {
        public Batchvalidator() {
            RuleFor(b => b.BusinessUnit).NotEmpty().NotNull().Matches(@"^[a-zA-Z ]+$");
                //.WithMessage("Enter valid input data.");
            RuleFor(b => b.ExpiryDate).NotEmpty().NotNull().Must(BeAValidDate)
                .WithMessage("Invalid date/time");
            RuleFor(b => b.ReadUsers).NotEmpty().NotNull().Matches(@"^[a-zA-Z ]+$");
               // .WithMessage("It must contain one or more letters.");
            RuleFor(b => b.ReadGroups).NotEmpty().NotNull().Matches(@"^[a-zA-Z ]+$");//.WithMessage("It must contain one or more letters.");
            RuleFor(b => b.KeyAttribute).NotEmpty().NotNull().Matches(@"^[a-zA-Z ]+$");//.WithMessage("It must contain one or more letters.");
            RuleFor(b => b.ValueAttribute).NotEmpty().NotNull().Matches(@"^[a-zA-Z ]+$");// WithMessage("It must contain one or more letters.");
            RuleFor(b => b.Status).NotEmpty().NotNull().Matches(@"^[a-zA-Z ]+$");
        }
        private bool BeAValidDate(string value)
        {
            DateTime date;
            return DateTime.TryParse(value, out date);
        }
    }
}
