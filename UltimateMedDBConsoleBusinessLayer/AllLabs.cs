using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UltimateMedDB.Business.dsUltimateMedDBTableAdapters;

namespace UltimateMedDB.Business
{
    public class AllLabs
    {
        public AllLabs()
        {
            Labs = new List<Lab>();
        }

        public static List<Lab> GetAllLabs()
        {
            LabTableAdapter taLabs = new LabTableAdapter();
            var dtLabs = taLabs.GetData();
            List<Lab> allLabs = new List<Lab>();

            foreach(dsUltimateMedDB.LabRow labRow in dtLabs.Rows)
            {
                Lab currentlab = new Lab
                {
                    Amount = labRow.Amount,
                    Category = labRow.Category,
                    Date = labRow.Date,
                    Doc_id = labRow.Doc_id,
                    Weight = labRow.Weight,
                    PatientType = labRow.PatientType

                };
                allLabs.Add(currentlab);
            }

            return allLabs;
        }

        public static void AddLab(Lab newLab, string Name)
        {
            LabTableAdapter taLabs = new LabTableAdapter();
            PatientTableAdapter patientLookUp = new PatientTableAdapter();
            int pid = (int)patientLookUp.GetPatientID(Name);
            int scope_id = Convert.ToInt32(taLabs.AddNewLabReturnScopeID(newLab.Weight, newLab.Doc_id, newLab.Date, newLab.Category, newLab.PatientType, newLab.Amount));
            Patient_LabTableAdapter labPatientConnect = new Patient_LabTableAdapter();
            labPatientConnect.InsertPidLabID(pid, scope_id);
            //Labs.Add(newLab);
        }


        public List<Lab> Labs;
    }
}
