using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS.Web.Client.Models;
using System.Runtime.Caching;

namespace TMS.Web.Client.Data
{

    public class DataRepository
    {
        public IList<Device> DeviceList()
        {
            IList<Device> deviceList = new List<Device>();

            deviceList = MemoryCache.Default.Get("devicelist") as List<Device>;
            if (deviceList == null)
            {
                deviceList = this.Devices();
                MemoryCache.Default.Add("devicelist", deviceList, DateTime.Now.AddMinutes(100));
            }
            return deviceList;
        }

        public IList<Device> EmployeeList()
        {
            return new List<Device>();
        }

        private IList<Device> Devices()
        {
            IList<Device> deviceList = new List<Device>();

            deviceList.Add(new Device() { Id = "0001010053415931", Name = "KUALA LUMPUR", Location = "KUALA LUMPUR", Status = "Active", Remarks = "Floor#2" });
            deviceList.Add(new Device() { Id = "RFS01SZ154901009", Name = "SHAH ALAM", Location = "SHAH ALAM", Status = "Active", Remarks = "Floor#12" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "KLANG", Location = "KLANG", Status = "Active", Remarks = "Floor#2" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "PETALING JAYA", Location = "PETALING JAYA", Status = "Active", Remarks = "Floor#3" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "RAWANG", Location = "RAWANG", Status = "Active", Remarks = "Floor#4" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "IPOH", Location = "IPOH", Status = "Active", Remarks = "Floor#7" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "KAJANG", Location = "KAJANG", Status = "Active", Remarks = "Floor#6" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "MELAKA", Location = "MELAKA", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "SEREMBAN", Location = "SEREMBAN", Status = "In Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "LANGKAWI", Location = "LANGKAWI", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "KANGAR", Location = "KANGAR", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "ALOR SETAR", Location = "ALOR SETAR", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "KANGAR", Location = "KANGAR", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "SUNGAI PETANI", Location = "SUNGAI PETANI", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "BUTTERWORTH", Location = "BUTTERWORTH", Status = "In Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "PULAU PINANG", Location = "PULAU PINANG", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "TAIPING", Location = "TAIPING", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "SUBANG JAYA", Location = "SUBANG JAYA", Status = "In Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "MUAR", Location = "MUAR", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "JOHOR BHARU", Location = "JOHOR BHARU", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "PASIR GUDANG", Location = "PASIR GUDANG", Status = "In Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "SEGAMAT", Location = "SEGAMAT", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "SENAI", Location = "SENAI", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "KLUANG", Location = "KLUANG", Status = "In Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "RAUB", Location = "RAUB", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "KUANTAN", Location = "KUANTAN", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "DUNGUN", Location = "DUNGUN", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "KOTA BHARU", Location = "KOTA BHARU", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "DUNGUN", Location = "DUNGUN", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "TEMERLOH", Location = "TEMERLOH", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "KUALA TERENGGANU", Location = "KUALA TERENGGANU", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "JB (LASHKAR)", Location = "JB (LASHKAR)", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "IPOH (KAWALAN)", Location = "IPOH (KAWALAN)", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "DUNGUN", Location = "DUNGUN", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "SUNGAI PETANI (BRILLIANT)", Location = "SUNGAI PETANI (BRILLIANT)", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "LANGKAWI (BRILLIANT)", Location = "LANGKAWI (BRILLIANT)", Status = "Active", Remarks = "Floor#5" });
            deviceList.Add(new Device() { Id = "0001010053415931", Name = "PULAU PINANG (BRILLIANT)", Location = "PULAU PINANG (BRILLIANT)", Status = "Active", Remarks = "Floor#5" });

            return deviceList;
        }

        private IList<Employee> Employees()
        {
            IList<Employee> employeeList = new List<Employee>();


            return employeeList;
        }
    }
}