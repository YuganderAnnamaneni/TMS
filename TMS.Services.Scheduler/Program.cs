using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TMS.Services.Repositories;
using TMS.Services.Models;
using System.Configuration;
using Dapper;
using System.Data.SqlClient;
using TMS.Utilities;
using System.Data;
using System.ComponentModel;

namespace TMS.Services.Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            MasterData masterData = new MasterData();

            masterData.PushDevicesToDB();
            masterData.PushAttendanceToDBByDevice();
        }
    }
}
