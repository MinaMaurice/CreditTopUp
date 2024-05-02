using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IBeneficiaryRepository BeneficiaryRepository { get; }
        IOptionRepository OptionRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
