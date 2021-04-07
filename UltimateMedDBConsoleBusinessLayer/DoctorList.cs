using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateMedDB.Business
{
    public class DoctorList
    {
        public DoctorList()
        {
            Doctors = new List<Doctor>();
        }

        public void AddDoctor(string Name, string Department)
        {
            Doctor doctor = new Doctor();
            doctor.Name = Name;
            doctor.Department = Department;
            Doctors.Add(doctor);
        }

        public List<Doctor> Doctors;
    }
}
