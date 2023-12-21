using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class ElectricityBill
    {
        public int BillId { get; set; }
        public int UnitsConsumed { get; set; }
        public decimal PricePerUnit { get; set; }
        public int KwAllowed { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal AfterDueDateCharges { get; set; }
        public BillStatus BillStatus { get; set; }

  
        public int? UserId { get; set; }
        public User? User { get; set; }
    }

}
