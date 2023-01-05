using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSMantenimiento.Models.ViewModels;
using WSMantenimiento.Response;

namespace WSMantenimiento.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
