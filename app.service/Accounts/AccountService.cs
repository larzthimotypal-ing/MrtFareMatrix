using System;
using System.Collections.Generic;
using System.Text;
using app.repository;
using app.service.Accounts.Commands.CreateAccount;

namespace app.service.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<app.domain.Accounts> _accountRepo;
        public AccountService(IRepository<domain.Accounts> accountRepo)
        {
            _accountRepo = accountRepo;
        }
        public CreateAccountResult CreateAccount(CreateAccountCommand command)
        {
            var entity = new domain.Accounts
            {
                EmailAddress = command.EmailAddress,
                FirstName = command.FirstName,
                LastName = command.LastName
            };

            _accountRepo.Create(entity);
            _accountRepo.SaveChanges();

            return new CreateAccountResult
            {
                Id = entity.ID
            };
        }

        
    }
}
