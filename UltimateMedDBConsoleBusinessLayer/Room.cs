using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateMedDB.Business.dsUltimateMedDBTableAdapters;

namespace UltimateMedDB.Business
{
    public class Room
    {
        public Room()
        {
            AvailableRooms = new List<Room>();
        }


        public static List<Room> GetAvailableRooms()
        {
            RoomTableAdapter taRoom = new RoomTableAdapter();
            var dtRoom = taRoom.GetData();
            List<Room> allRooms = new List<Room>();

            foreach(dsUltimateMedDB.RoomRow roomRow in dtRoom)
            {
                if(roomRow.Status == "available")
                {
                    Room currentRoom = new Room
                    {
                        Status = roomRow.Status,
                        Number = roomRow.Room_no,
                        Type = roomRow.RoomType
                    };
                    currentRoom.AvailableRooms.Add(currentRoom);
                    allRooms.Add(currentRoom);
                }
            }
            return allRooms;
        }

        public static void AssignRoom(int roomNumber, string patientName)
        {
            PatientTableAdapter taPatient = new PatientTableAdapter();
            int patient_id = (int)taPatient.GetPatientID(patientName);
            RoomTableAdapter taRoom = new RoomTableAdapter();
            taRoom.UpdateRoomStatus("occupied", roomNumber);
            int room_id = (int)taRoom.GetRoomID(roomNumber);
            Patient_RoomTableAdapter taPatientRoom = new Patient_RoomTableAdapter();
            taPatientRoom.InsertRoomByPidScopeID(patient_id, room_id);
        }

        public static void UnassignRoom(int roomNumber, string patientName)
        {
            PatientTableAdapter taPatient = new PatientTableAdapter();
            int patient_id = (int)taPatient.GetPatientID(patientName);
            RoomTableAdapter taRoom = new RoomTableAdapter();
            taRoom.UpdateRoomStatus("available", roomNumber);
            int room_id = (int)taRoom.GetRoomID(roomNumber);
            Patient_RoomTableAdapter taPatientRow = new Patient_RoomTableAdapter();
            taPatientRow.UnassignRoom(patient_id, room_id);
        }

        public static string GetRoomStatus(int roomNumber)
        {
            RoomTableAdapter taRoom = new RoomTableAdapter();
            string status = taRoom.CheckRoomStatus(roomNumber);
            return status;
        }

        public static bool AddNewRoom(Room newRoom)
        {
            RoomTableAdapter taRoom = new RoomTableAdapter();
            string status = taRoom.CheckRoomStatus(newRoom.Number);
            if (status == "available" || status == "occupied")
                return false;
            else
            {
                taRoom.InsertRoomData(newRoom.Number, newRoom.Type, "available");
                return true;
            }

        }

        public static bool RemoveRoom(int roomNumber)
        {
            RoomTableAdapter taRoom = new RoomTableAdapter();
            string status = taRoom.CheckRoomStatus(roomNumber);
            if (status != "occupied")
            {
                taRoom.RemoveRoom(roomNumber);
                return true;
            }
            else
                return false;
        }

        public List<Room> AvailableRooms { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }
}
