using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using System.IO;

namespace FlooringMastery.Data.Prod
{
    public class ProductionTaxInformationRepository : IStateTaxInformationRepository
    {
        public List<Taxes> ListAll()
        {
            List<Taxes> taxes = new List<Taxes>();

            var reader = File.ReadAllLines(@"DataFiles/Taxes.txt");

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var stateTax = new Taxes();

                stateTax.StateAbbreviation = columns[0];
                stateTax.TaxRate = decimal.Parse(columns[1]);

                taxes.Add(stateTax);
            }
            return taxes;
        }
    }
}
