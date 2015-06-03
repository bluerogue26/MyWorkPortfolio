using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGBank.Models
{
    public class DepositReceipt
    {
        public int AccountNumber { get; set; }
        public decimal NewBalance { get; set; }
    }
}
