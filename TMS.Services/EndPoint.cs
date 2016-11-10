namespace TMS.Services
{
    /// <summary>
    /// TMS Endpoints contains api action methods for each endpoint.
    /// </summary>
    public class EndPoint
    {
        public const string UserLogin = "api/user/login";

        public const string GetDeviceList = "api/device/list";

        public const string AddNewDevice = "api/device/{deviceid}";

        public const string EditDevice = "api/device/{deviceid}";

        public const string GetDevice = "api/device/{deviceid}";

        public const string GetAttendanceByDevice = "api/device/{deviceid}?start_time={start_time}&end_time={end_time}&start_counter={start_counter}";

        public const string GetAttendanceByTag = "api/tag/{tagid}?start_time={start_time}&end_time={end_time}&start_counter={start_counter}";

        public const string GetAllDeviceStatus = "api/devicestatus";

        public const string GetDeviceStatus = "api/devicestatus/{deviceid}";
    }
}
