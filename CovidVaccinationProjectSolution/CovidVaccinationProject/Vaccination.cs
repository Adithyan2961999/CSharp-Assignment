using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccinationProject
{
    public enum VaccinationType
    {
        Covishield = 1,
        Covaxin,
    }
    class Vaccination
    {
       
        public VaccinationType vacc { get; set; }
        private static int _dosage = 1;
        public DateTime Date { get; set; }
        public int Dose { get; set; }

        public void vaccinationType(VaccinationType vac )
        {
            this.vacc = vac;
            this.Dose = _dosage;
            _dosage++;
            this.Date = DateTime.Now;
        }
        
    }
}
