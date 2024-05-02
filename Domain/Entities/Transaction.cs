using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public int BeneficiaryID { get; set; }
        public int OptionID { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }

        public User User { get; set; }
        public Beneficiary Beneficiary { get; set; }
        public TopUpOption TopUpOption { get; set; }
    }
}
