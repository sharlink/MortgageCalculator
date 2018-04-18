using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MortgageCalculator.Api.Helper;
using MortgageCalculator.Dto;
using AutoMapper;
using MortgageCalculator.Api.Services;
using MortgageCalculator.Api.Models;

namespace MortgageCalculator.Api.Repos
{
    public class MortgageRepo : IMortgageService
    {
        public IEnumerable<Mortgage> GetAllMortgages()
        {
            using (var context = new MortgageData.MortgageDataContext())
            {
                var mortgages = context.Mortgages.OrderBy(x => x.MortgageType)
                                                 .ThenBy(x => x.InterestRate)
                                                 .ToList();

                return Mapper.Map<IEnumerable<Mortgage>>(mortgages);
            }
        }

        public List<DropdownKeyValue> GetMortgageType()
        {
            var result = new List<DropdownKeyValue>();
            Array mortgage = Enum.GetValues(typeof(MortgageType));

            foreach (var item in mortgage)
            {
                result.Add(new DropdownKeyValue { Key = ((int)item).ToString(), Value = item.ToString() });
            }
            return result;
        }
    }
}