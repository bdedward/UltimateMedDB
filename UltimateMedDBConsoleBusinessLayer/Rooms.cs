using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateMedDB.Business.dsUltimateMedDBTableAdapters;

namespace UltimateMedDB.Business
{
    public class Rooms
    {
        public Rooms()
        {
            HosptialRooms = new List<Room>();
        }

        public static List<Room> GetAllRooms()
        {
            RoomTableAdapter taRooms = new RoomTableAdapter();
            var dtRooms = taRooms.GetData();
            List<Room> allRooms = new List<Room>();

            foreach(dsUltimateMedDB.RoomRow roomRow in dtRooms)
            {
                Room currentRoom = new Room();
                Rooms newRoom = new Rooms();
                currentRoom.Number = roomRow.Room_no;
                currentRoom.Status = roomRow.Status;
                currentRoom.Type = roomRow.RoomType;
                newRoom.AddNewRoom(currentRoom.Number, currentRoom.Type, currentRoom.Status);

                allRooms.Add(currentRoom);
            }

            return allRooms;
        }

        public void AddNewRoom(int Number, string Type, string Status)
        {
            Room newRoom = new Room
            {
                Number = Number,
                Type = Type,
                Status = Status
            };
            RoomTableAdapter taRoom = new RoomTableAdapter();
            taRoom.InsertRoomData(Number, Type, Status);
            HosptialRooms.Add(newRoom);
        }

        public void AssignPatientToRoom(string Name, int Number)
        {
            RoomTableAdapter roomCheck = new RoomTableAdapter();
            string roomStatus = roomCheck.CheckRoomStatus(Number);
            if (roomStatus != "Available")
            {
                Console.WriteLine("This room is not available to be assigned. Please try another Room.");
            }
            else
            {
                PatientTableAdapter patientLookUp = new PatientTableAdapter();
                int pid = (int)patientLookUp.GetPatientID(Name);
                RoomTableAdapter roomNumberLookUp = new RoomTableAdapter();
                int room_id = (int)roomNumberLookUp.GetRoomID(Number);
                Patient_RoomTableAdapter roomId = new Patient_RoomTableAdapter();
                roomId.InsertRoomByPidScopeID(pid, Convert.ToInt32(room_id));
            }
        }

        public void ModifyRoomStatus(int Number, string Status) 
        {
            RoomTableAdapter modifyRoom = new RoomTableAdapter();
            modifyRoom.UpdateRoomStatus(Status, Number);
        }


        
        public List<Room> HosptialRooms { get; set; }
    }
}
