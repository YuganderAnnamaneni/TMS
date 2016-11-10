using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Services.Models;

namespace TMS.Services.Repositories
{
    public interface IUserClient
    {
        User Login(User user);
    }
}
