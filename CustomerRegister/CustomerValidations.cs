using FluentValidation;
using System.Linq;

namespace CustomerRegister
{
    public class CustomerValidations : AbstractValidator<CustomerEntity>
    {
        public CustomerValidations() {
            RuleFor(x => x.FullName).
                NotNull().
                NotEmpty();

            RuleFor(x => x.Email).
                NotEqual("").
                NotEmpty().
                MinimumLength(4).
                EmailAddress().Equal(x => x.EmailConfirmation);

            RuleFor(x => x.Cpf).
                NotEqual(" ").
                NotEmpty().
                Length(11).
                Must(IsValidCpf).WithMessage("Por favor insira um CPF válido, este CPF está incorreto");

            RuleFor(x => x.Cellphone).
                NotEqual("").
                NotEmpty();

            RuleFor(x => x.DataOfBirth).           
                NotEmpty();

            RuleFor(x => x.EmailSms).
                NotEmpty();

            RuleFor(x => x.Whatsapp).
                NotEmpty();

            RuleFor(x => x.Country).
                NotEqual("").
                NotEmpty();

            RuleFor(x => x.City).
                NotEqual("").
                NotEmpty();

            RuleFor(x => x.PostalCode).
                NotEqual("").
                NotEmpty();

            RuleFor(x => x.Address).
                NotEqual("").
                NotEmpty();

            RuleFor(x => x.AddressNumber).
                NotEmpty();
        }

        bool IsValidCpf(string cpf)
        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            if (cpf.Length != 11) return false;
            if (cpf.All(x => x == cpf.First())) return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
