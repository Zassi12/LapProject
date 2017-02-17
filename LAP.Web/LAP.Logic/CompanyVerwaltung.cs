using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAP.Logic
{
    class CompanyVerwaltung
    {

        /// <summary>
        /// Returns a list with all companies
        /// 
        /// </summary>
        /// <returns>list company</returns>
        static List<company> GetCompanies()
        {
            var CompanyListe = new List<company>();
            var context = new ITIN20LAPEntities();
            CompanyListe = context.companies.ToList();
            return CompanyListe;
        }
        static List<CompanyData> GetCompanyUser()
        {
            var Companyuserlist = new List<CompanyData>();



            return Companyuserlist;
        }



        class CompanyData
        {
            public company Company { get; set; }

            public List<portaluser> Users { get; set; }
        }
        
    }
}
