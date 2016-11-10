using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Services.Models;

namespace TMS.Services.Repositories
{
    public interface ITagClient
    {
        BaseResponse<List<Tag>> GetAttendanceByTagId(string tagId, string startTime, string endTime, string startCounter);
    }
}
