using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccinationProject
{

    //Main Menu Options to choose options from the User
    class Program
    {
        Beneficiary CurrentBenificary;
        Beneficiary s = new Beneficiary();
        Vaccination v = new Vaccination();
        List<Beneficiary> BeneficiaryList = new List<Beneficiary>();
        static void Main(string[] args)
        {
            string exitoption="no";
            Program People = new Program();
            Console.WriteLine("------------------COVID VACCINATION------------------");
            Console.WriteLine();
            do
            {
                Console.WriteLine("CHOOSE OPTIONS  : ");
                Console.WriteLine();
                Console.WriteLine(" Beneficiary Registration -> 1 \n Vaccination -> 2 \n Exit -> 3");
                Console.WriteLine("---------------------------------------------------------------");
                int UserInput;
                    Console.Write("Enter your option : ");
                    UserInput = int.Parse(Console.ReadLine());
                    switch (UserInput)
                    {
                        case 1:
                            {
                                People.BeneficiaryRegistration();
                            Console.WriteLine();
                            Console.WriteLine("Do you want to go Main menu - YES or NO");
                            exitoption = Console.ReadLine();
                                break;
                            }
                        case 2:
                            {
                            People.Vaccination();
                                break;
                            }
                        case 3:
                            {
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid Input ");
                            Console.WriteLine();
                            Console.WriteLine("Do you want to go to main menu - YES or NO ");
                            exitoption = Console.ReadLine();
                                break;
                            }
                    }
             
            } while (exitoption.ToLower() == "yes");
            Console.Write("Thank You !");

            Console.ReadLine();
        }
        //This method is used to Add the Beneficiary Details...
        public void BeneficiaryRegistration()
        {
            int Age;
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("******BENEFICIARY REGISTRAION******");
            Console.WriteLine();
            Console.Write("Enter your Name : ");
            string Name = Console.ReadLine();
            Console.Write("Enter your Mobile Number : ");
            long MobileNum = long.Parse(Console.ReadLine());
            Console.Write("Enter your Age : ");
            Age = int.Parse(Console.ReadLine());
            Console.Write("Choose your Genter :  \nMale -> 1 \nFemale -> 2  \nTransgenter -> 3 \n");
            Genter gen = (Genter)int.Parse(Console.ReadLine());
            string Gen = string.Empty;
            Console.Write("Enter your City : ");
            string City = Console.ReadLine();
            s.Benificiaryregistration(Name, MobileNum, City, Age, (Genter)gen);
            s.DisplayRegNo();
            BeneficiaryList.Add(s);
                         
        }

        //This method is used to Add, show details and show next due date...
        public void Vaccination()
        {
            Console.Write("Enter your Register Number : ");
            int regNo = int.Parse(Console.ReadLine());
            Console.WriteLine();
            foreach(var c in BeneficiaryList)
            {
                if (c.RegistrationNum == regNo)
                {
                    CurrentBenificary = c;
                    String user="no";
                    do
                    {
                        Console.WriteLine("CHOOSE OPTION : ");
                        Console.WriteLine();
                        Console.WriteLine("Take vaccination -> 1 \nVaccination History -> 2 \nNext Due Date -> 3 \nMain Menu -> 4");
                        Console.Write("Enter your option : ");
                        int num = int.Parse(Console.ReadLine());
                        switch (num)
                        {
                            case 1:
                                {
                                    
                                        Console.WriteLine("Enter the Vaccination Type : \nCovishield -> 1 \nCovaxin -> 2");
                                        VaccinationType vac = (VaccinationType)int.Parse(Console.ReadLine());
                                        v.vaccinationType(vac);
                                        if (CurrentBenificary.VaccinationDetails == null)
                                        {
                                        CurrentBenificary.VaccinationDetails = new List<Vaccination>();
                                        CurrentBenificary.VaccinationDetails.Add(v);
                                    }
                                        if (CurrentBenificary.VaccinationDetails.Count == 1)
                                        {
                                            Console.WriteLine("You have successfully Vaccinated 1st Dose ");
                                        }
                                        if (CurrentBenificary.VaccinationDetails.Count == 2)
                                        {
                                            Console.WriteLine("You have successfully vaccinated 2nd Dose ");
                                        }
                                    

                                    break;
                                }
                            case 2:
                                {
                                    int i = 0;
                                    foreach(var d in BeneficiaryList)
                                    {
                                        if(d.RegistrationNum == regNo)
                                        {

                                                Console.WriteLine();
                                                Console.WriteLine($"Name : {d.Name} \nPhone No : {d.MobileNum} \nGenter : {d.genter} \nCity : {d.City} \nVaccination : {d.VaccinationDetails[0].vacc} ");
                                                if (d.VaccinationDetails.Count == 1 || d.VaccinationDetails.Count == 2)
                                                {
                                                    Console.WriteLine("Dose : 1");
                                                    Console.WriteLine("1st Dose Date : {0}", d.VaccinationDetails[0].Date);
                                                }
                                                if (d.VaccinationDetails.Count == 2)
                                                {
                                                    Console.WriteLine("Dose : 2");
                                                    Console.WriteLine("2nd Dose Date : {0}", d.VaccinationDetails[0].Date);
                                                }
                                                i++;
                                                Console.WriteLine();
                                            
                                           
                                        }
                                    }
                                    
                                    break;
                                }
                            case 3:
                                {
                                    foreach(var d in BeneficiaryList)
                                    {
                                        if(d.RegistrationNum == regNo)
                                        {
                                            if(d.VaccinationDetails.Count == 1)
                                            {
                                                Console.WriteLine($"You have taken 1st dose on {d.VaccinationDetails[0].Date} \nYour 2nd Dose Due date is on {d.VaccinationDetails[0].Date.AddDays(30)}");
                                            }
                                            if(d.VaccinationDetails.Count == 2)
                                            {
                                                Console.WriteLine("You have completed the vaccination course. Thanks for your participation in the vaccination drive");
                                            }
                                        }
                                    }

                                    break;
                                }
                            case 4:
                                {
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Invalid Input ");
                                    break;
                                }
                        }
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Do you want to go to Choose Option - YES or NO ");
                        user = Console.ReadLine();
                    } while (user.ToLower() == "yes");
                }
            }
        }

    }
}
