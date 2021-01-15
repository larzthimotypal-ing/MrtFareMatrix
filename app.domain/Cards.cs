using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace app.domain
{
    public class Cards : BaseEntity
    {
        [DisplayName("Account ID")]
        public int AccountID { get; set; }

        public Accounts Accounts { get; set; }

        [DisplayName("Card Classifications")]
        [StringLength(50)]
        public string CardClassifications { get; set; }

        [DisplayName("Credit Points")]
        public float CreditPoints { get; set; }

        [DisplayName("Usage Number")]
        public int UsageNumber { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        [DisplayName("Stolen Cards")]
        public bool StolenCards { get; set; }

    }
}
