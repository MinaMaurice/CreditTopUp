using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BeneficiaryId { get; set; }
        public int OptionId { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
