using CIM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIM.Repo.Interface
{
    public interface ICountryRepo
    {
        IEnumerable<Country> GetCountries();
        void SaveCountry(Country country);
    }
}
