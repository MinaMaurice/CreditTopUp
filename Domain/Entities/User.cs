using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public bool VerificationStatus { get; set; }
        public decimal Balance { get; set; }
        public List<Beneficiary> Beneficiaries { get; set; }

    }
}
