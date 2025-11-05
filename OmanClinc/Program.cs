using OmanClinc.Models;

namespace OmanClinc
{
    internal class Program
    {
        static void Main(string[] args)
        {
          

                ClincSystem clinic = new ClincSystem();
                int choice;

                do
                {
                    Console.WriteLine("============================================");
                    Console.WriteLine("     Welcome to Oman Clinic Appointment System");
                    Console.WriteLine("============================================");
                    Console.WriteLine("1. Register New Patient");
                    Console.WriteLine("2. Add New Doctor");
                    Console.WriteLine("3. Search Doctor by Specialty");
                    Console.WriteLine("4. Book Appointment");
                    Console.WriteLine("5. View Patient Appointments");
                    Console.WriteLine("6. View All Appointments");
                    Console.WriteLine("7. Exit");
                    Console.Write("\nEnter your choice: ");

                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine(" Invalid input. Try again.\n");
                        continue;
                    }

                    Console.WriteLine();

                    switch (choice)
                    {
                        case 1: clinic.RegisterPatient(); break;

                        case 2: clinic.AddDoctor(); break;

                        case 3: clinic.SearchDoctorBySpecialty(); break;

                        case 4: clinic.BookAppointment(); break;

                        case 5: clinic.ViewPatientAppointments(); break;


                        case 6: clinic.ViewAllAppointments(); break;

                        case 7:
                            Console.WriteLine("Thank you for using Oman Clinic Appointment System. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }

                    Console.WriteLine("--------------------------------------------\n");

                } while (choice != 7);
            }
        }
    }

