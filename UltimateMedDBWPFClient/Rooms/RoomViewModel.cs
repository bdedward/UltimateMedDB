using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateMedDB.Business;

namespace UltimateMedDBWPFClient.Rooms
{
    public class RoomViewModel : BindableBase
    {

        public List<Patient> AllPatients
        {
            get
            {
                return Patient.GetAllPatients();
            }
        }
        private Patient _selectedPatient = new Patient();
        public Patient SelectedPatient
        {
            get
            {
                return _selectedPatient;
            }
            set
            {
                _selectedPatient = value;
            }
        }

        public List<Room> AvailableRooms
        {
            get
            {
                return Room.GetAvailableRooms();
            }
        }

        private Room _newRoom = new Room();
        public Room NewRoom
        {
            get
            {
                return _newRoom;
            }
            set
            {
                _newRoom = value;
            }

        }


    }
}
