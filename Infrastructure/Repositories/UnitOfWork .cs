using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

       public IUserRepository UserRepository { get; }
        public IBeneficiaryRepository BeneficiaryRepository { get; }
        public IOptionRepository OptionRepository { get; }
        public ITransactionRepository TransactionRepository { get; }

        public UnitOfWork(AppDbContext AppDbContext, IUserRepository userRepository,
                      IBeneficiaryRepository beneficiaryRepository,
                      IOptionRepository optionRepository,
                      ITransactionRepository transactionRepository)
        {
            this._dbContext = AppDbContext;
            UserRepository = userRepository;
            BeneficiaryRepository = beneficiaryRepository;
            OptionRepository = optionRepository;
            TransactionRepository = transactionRepository;
        }
        public Task<int> SaveChangesAsync()
        {
           return _dbContext.SaveChangesAsync();
        }
    }
}
