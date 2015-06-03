using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data.Test
{
    public class TestTaxInformationRepository : IStateTaxInformationRepository
    {
        public List<Taxes> ListAll()
        {
            return new List<Taxes>()
            {
                new Taxes() { StateAbbreviation = "OH", StateName = "Ohio", TaxRate = 6.25M},
                new Taxes() { StateAbbreviation = "PA", StateName = "Pennsylvania", TaxRate = 7.5M},
                new Taxes() { StateAbbreviation = "NY", StateName = "New York", TaxRate = 10.0M},
            };
        }
    }
}
