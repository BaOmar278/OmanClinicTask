using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OmanClinc.Models
{
    public class ClincSystem
    {
        private List<Patient> patients = new List<Patient>();
        private List<Doctor> doctors = new List<Doctor>();
        private List<Appointment> appointments = new List<Appointment>();
        private List<Specialty> specialties = new List<Specialty>();

        public ClincSystem()
        {
         
            specialties.Add(new Specialty(1, "Pediatrics"));
            specialties.Add(new Specialty(2, "Cardiology"));
            specialties.Add(new Specialty(3, "Dermatology"));
        }


        public void RegisterPatient()
        {
            Console.WriteLine("-- Register New Patient --");
            Console.Write("Enter Patient Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter National ID: ");
            string nationalId = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            patients.Add(new Patient(patients.Count + 1, name, nationalId, phone));
            Console.WriteLine($" Patient {name} registered successfully!");
        }

        public void AddDoctor()
        {
            Console.WriteLine("Enter Doctor ID:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Doctor  Name:");
            string Name = Console.ReadLine();


            Console.WriteLine("Enter Doctor Phone:");
            string phone = Console.ReadLine();


            Console.WriteLine("Enter Doctor Specialty:");
            string specialtyName = Console.ReadLine();

            var specialty = specialties.Find(s => s.SpecialtyName.ToLower() == specialtyName.ToLower());

            if (specialty == null)
            {
                Console.WriteLine("Specialty not found. Please register this specialty first.");
                return;
            }


            Doctor doc = new Doctor(id,Name,phone,specialty);
          

            doctors.Add(doc);

            Console.WriteLine($"Doctor {Name} added successfully under {specialty.SpecialtyName}.");
        }





        public void SearchDoctorBySpecialty()
        {
            Console.WriteLine("-- Search Doctor by Specialty --");
            Console.Write("Enter Specialty to search: ");
            string specialtyName = Console.ReadLine().ToLower();

            bool foundAny = false;

            Console.WriteLine("\nDoctors Found:");

            foreach (var doc in doctors)
            {
                if (doc.Specialty.SpecialtyName.ToLower() == specialtyName)
                {
                    Console.WriteLine($"- {doc.FullName} | Phone: {doc.DoctorPhone}");
                    foundAny = true;
                }
            }

            if (!foundAny)
                Console.WriteLine("No doctors found for this specialty.");
        }


        public void BookAppointment()
        {
            Console.WriteLine("-- Book Appointment --");
            Console.Write("Enter Patient National ID: ");
            string nationalId = Console.ReadLine();
            Console.Write("Enter Doctor Name: ");
            string doctorName = Console.ReadLine();
            Console.Write("Enter Appointment Date (dd/MM/yyyy): ");
            string dateInput = Console.ReadLine();

            if (!DateTime.TryParse(dateInput, out DateTime date))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            var patient = patients.FirstOrDefault(p => p.NationalId == nationalId);
            var doctor = doctors.FirstOrDefault(d =>
                d.FullName.Equals(doctorName, StringComparison.OrdinalIgnoreCase));

            if (patient == null || doctor == null)
            {
                Console.WriteLine("Patient or Doctor not found.");
                return;
            }

            bool doctorBusy = appointments.Any(a =>
                a.Doctor.DoctorId == doctor.DoctorId && a.AppointmentDate.Date == date.Date);

            if (doctorBusy)
            {
                Console.WriteLine(" Doctor is already booked on this date.");
                return;
            }

            appointments.Add(new Appointment(appointments.Count + 1, date, patient, doctor));
            Console.WriteLine(" Appointment booked successfully!");
        }

        public void ViewPatientAppointments()
        {
            Console.WriteLine("-- View Patient Appointments --");
            Console.Write("Enter Patient National ID: ");
            string nationalId = Console.ReadLine();

            var patient = patients.FirstOrDefault(p => p.NationalId == nationalId);
            if (patient == null)
            {
                Console.WriteLine(" Patient not found.");
                return;
            }

            var patientAppointments = appointments
                .Where(a => a.Patient.PatientId == patient.PatientId).ToList();

            if (patientAppointments.Count == 0)
            {
                Console.WriteLine("No appointments found for this patient.");
                return;
            }

            Console.WriteLine($"Appointments for {patient.FullName}:");
            foreach (var app in patientAppointments)
            {
                Console.WriteLine($"- Date: {app.AppointmentDate:dd/MM/yyyy} | Doctor: {app.Doctor.FullName} | Specialty: {app.Doctor.Specialty.SpecialtyName}");
            }
        }

        
        public void ViewAllAppointments()
        {
            Console.WriteLine("-- View All Appointments --");

            if (appointments.Count == 0)
            {
                Console.WriteLine(" No appointments booked yet.");
                return;
            }

            Console.WriteLine(" All Booked Appointments:");
            int i = 1;
            foreach (var app in appointments)
            {
                Console.WriteLine($"{i++}. Patient: {app.Patient.FullName} | Doctor: {app.Doctor.FullName} | Date: {app.AppointmentDate:dd/MM/yyyy} | Specialty: {app.Doctor.Specialty.SpecialtyName}");
            }
        }



    }
}
