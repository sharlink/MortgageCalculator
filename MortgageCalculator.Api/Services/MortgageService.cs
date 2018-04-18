using System.Collections.Generic;
using MortgageCalculator.Api.Models;
using MortgageCalculator.Api.Repos;
using MortgageCalculator.Dto;

namespace MortgageCalculator.Api.Services
{
    public interface IMortgageService
    {
        IEnumerable<Mortgage> GetAllMortgages();
        List<DropdownKeyValue> GetMortgageType();
    }   
}