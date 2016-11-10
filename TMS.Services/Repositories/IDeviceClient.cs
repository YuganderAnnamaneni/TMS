using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Services.Models;

namespace TMS.Services.Repositories
{
    public interface IDeviceClient
    {
        BaseResponse<List<Device>> GetDeviceList();

        BaseResponse<Device> AddNewDevice(Device device);

        BaseResponse<Device> EditDevice(Device device);

        bool DeleteDevice(Device device);

        BaseResponse<List<Device>> GetDeviceByDeviceId(string deviecId);

        BaseResponse<List<Device>> GetAttendanceByDeviceId(string deviecId, string startTime, string endTime, string startCounter);

        BaseResponse<List<DeviceStatus>> GetAllDeviceStatus();

        BaseResponse<List<DeviceStatus>> GetDeviceStatus(string deviceId);    
    }
}
