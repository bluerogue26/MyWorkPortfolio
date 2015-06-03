using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.BLL
{
    public class TaxManager
    {
        private IStateTaxInformationRepository _myStateTaxInformationRepository;

        public TaxManager(IStateTaxInformationRepository aStateTaxInformationRepository)
        {
            _myStateTaxInformationRepository = aStateTaxInformationRepository;
        }

        public List<Taxes> ListAll()
        {
            return _myStateTaxInformationRepository.ListAll();
        }

        public decimal GetRate(string stateAbbreviation)
        {
            var allStates = _myStateTaxInformationRepository.ListAll();

            var state = allStates.First(s => s.StateAbbreviation == stateAbbreviation);

            return state.TaxRate;
        }

        public bool IsValidState(string stateAbbreviation)
        {
            var allStates = _myStateTaxInformationRepository.ListAll();

            return allStates.Any(s => s.StateAbbreviation == stateAbbreviation);
        }

        public Taxes GetSingleState(string stateName)
        {
            var allStates = _myStateTaxInformationRepository.ListAll();

            foreach (var state in allStates)
            {
                if (state.StateAbbreviation == stateName)
                {
                    return state;
                }
            }
            return null;
        }
    }
}
