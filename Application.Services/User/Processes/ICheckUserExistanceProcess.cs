using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.User.Processes
{
    public interface ICheckUserExistanceProcess
    {
        bool IsUserExist(string loginToken);
    }
}
