using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User
{
    public interface IUser : IUserAspect, IUserInfoAspect
    {
    }
}
