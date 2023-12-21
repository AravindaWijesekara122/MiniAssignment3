using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public UserRole Role { get; set; }
        public string MobileNo { get; set; }
        public string AlternativeNumber { get; set; }
        public int Pincode { get; set; } // Pincode as an integer
        public KWAllowed KwAllowed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation property for the associated bills
        public ICollection<ElectricityBill>? ElectricityBills { get; set; } = new List<ElectricityBill>();
    }



}
