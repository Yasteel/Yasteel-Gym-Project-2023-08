namespace GymApp.API.Validators
{
    using FluentValidation;
    using Models.Models;

    public class MembersValidator : AbstractValidator<Members>
    {
        public MembersValidator()
        {
            this.RuleSet("Create", () =>
            {

            });
        }


        private void GeneralRules()
        {

        }

        //private void CreateValidator()
        //{
        //    //this.RuleFor(_ => _.);
        //}

    }
}
