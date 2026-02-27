using System.ComponentModel.DataAnnotations;
 
namespace InvestmentBackend.Models
{
    public class Investment
    {
        [Key]
        public int InvestmentId { get; set; }
 
        [Required]
        public string InvestmentName { get; set; }
 
        [Required]
        public string InvestmentType { get; set; }
 
        public string Description { get; set; }
 
        public bool IsActive { get; set; }
 
        public DateTime CreatedOn { get; set; }
 
        public DateTime MaturityDate { get; set; }
 
        public decimal InvestmentAmount { get; set; }
 
        public decimal CurrentValue { get; set; }
 
        [Required]
        public string RiskLevel { get; set; } // Low | Medium | High
 
        public string Tags { get; set; }
    }
}
 

 