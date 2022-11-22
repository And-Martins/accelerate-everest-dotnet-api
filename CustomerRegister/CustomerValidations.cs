using FluentValidation;
using System.Linq;

namespace CustomerRegister
{
    public class CustomerValidations : AbstractValidator<CustomerEntity>
    {
        public CustomerValidations() {
            RuleFor(x => x.FullName).
                NotEmpty();

            RuleFor(x => x.Email).
                NotEmpty().
                MinimumLength(4).
                EmailAddress().Equal(x => x.EmailConfirmation);

            RuleFor(x => x.Cpf).
                NotEmpty().
                Must(IsValidCpf).WithMessage("Por favor insira um CPF válido, este CPF está incorreto");

            RuleFor(x => x.Cellphone).
                NotEmpty();

            RuleFor(x => x.DataOfBirth).           
                NotEmpty();

            RuleFor(x => x.Country).
                NotEmpty();

            RuleFor(x => x.City).
                NotEmpty();

            RuleFor(x => x.PostalCode).
                NotEmpty();

            RuleFor(x => x.Address).
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

            if (cpf.All(x => x == cpf.First())) return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
                
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
