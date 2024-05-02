using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enums
{
    public enum TopUpResult
    {
        Success,
        UserNotFound,
        OptionNotFound,
        BeneficiaryNotFound,
        InsufficientBalance,
        MaxTopUpPerMonthExceeded,
        MaxTotalTopUpPerMonthExceeded
    }
}
