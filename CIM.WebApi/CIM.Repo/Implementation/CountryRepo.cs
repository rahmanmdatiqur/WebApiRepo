using CIM.DAL.Interface;
using CIM.Models;
using CIM.Repo.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIM.Repo.Implementation
{
    public class CountryRepo : ICountryRepo
    {
        private readonly IGenericRepo<Country> _cntryRepo;
        public CountryRepo(IGenericRepo<Country> cntryRepo)
        {
            this._cntryRepo = cntryRepo;
        }
        public IEnumerable<Country> GetCountries()
        {
            try
            {
                return _cntryRepo.FindAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SaveCountry(Country country)
        {
            try
            {
                _cntryRepo.Create(country);
                _cntryRepo.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
