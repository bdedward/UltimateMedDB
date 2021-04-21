using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UltimateMedDB.Business;

namespace UMDBBusinessLayerTest
{
    [TestClass]
    public class PatientTest
    {
        [TestMethod]
        public void PatientFieldTestValid()
        {
            //-- Arrange
            Patient patient = new Patient
            {
                Name = "Frodo Baggins",
                Gender = "Male",
                Phone = "4801235555",
                Weight = 155,
                Address = "1234 1337 Lane"
            };
            string expectedName = "Frodo Baggins";
            string expectedGender = "Male";
            string expectedPhone = "4801235555";
            int expectedWeight = 155;
            string expectedAddress = "1234 1337 Lane";
            //-- Act
            string actualName = patient.Name;
            string actualGender = patient.Gender;
            string actualPhone = patient.Phone;
            int actualWeight = patient.Weight;
            string actualAddress = patient.Address;

            //-- Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedGender, actualGender);
            Assert.AreEqual(expectedPhone, actualPhone);
            Assert.AreEqual(expectedWeight, actualWeight);
            Assert.AreEqual(expectedAddress, actualAddress);
        }

    }
}
