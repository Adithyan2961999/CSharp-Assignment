using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccinationProject
{
    public enum Genter
    {
        Male = 1,
        Female,
        Transgender
    }
    class Beneficiary
    {

        private static int _registrationNo = 1001;
        
        public string Name { get; set; }
        public long MobileNum { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public Genter genter { get; set; }
        public int RegistrationNum { get; set; }


        public List<Vaccination> VaccinationDetails = new List<Vaccination>();

        public void Benificiaryregistration(string name, long mobNo, string ad, int age, Genter gen)
            {
                this.Name = name;
                this.MobileNum = mobNo;
                this.City = ad;
                this.Age = age;
                this.genter = gen;
            this.RegistrationNum = _registrationNo;
                _registrationNo++;
            }
        public void DisplayRegNo()
        {
            Console.WriteLine("Your registration Number : " + RegistrationNum);
        }
    }
}
