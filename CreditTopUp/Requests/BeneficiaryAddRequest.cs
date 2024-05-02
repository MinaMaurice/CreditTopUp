using System.ComponentModel.DataAnnotations;

namespace CreditTopUp.Requests
{
    public class BeneficiaryAddRequest
    {
        [StringLength(20, ErrorMessage = "Nickname length must not exceed 20 characters.")]
        public string Nickname { get; set; }
    }
}
