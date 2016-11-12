using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TMS.Services.Repositories;
using TMS.Services.Models;
using System.Configuration;

namespace TMS.Services.Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            string clientURL = ConfigurationManager.AppSettings["clientURL"];

            IUserClient userClient = new UserClient(clientURL);

            var user = userClient.Login(new User()
                 {
                     UserId = "cms",
                     Password = "cmstestingpassword"
                 });

            IDeviceClient deviceClient = new DeviceClient(user.AuthToken, clientURL);

            var deviceList = deviceClient.GetDeviceList();
            var attendanceListByDevice = deviceClient.GetAttendanceByDeviceId(deviecId: "", startTime: "", endTime: "", startCounter: "");
            var deviceStatusList = deviceClient.GetDeviceStatus(deviceId: "");


        }
    }
}
