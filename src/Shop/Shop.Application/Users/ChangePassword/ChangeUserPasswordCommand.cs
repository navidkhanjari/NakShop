using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Users.ChangePassword
{
    public record ChangeUserPasswordCommand(Guid UserId, string NewPassword, string CurrentPassword) : IBaseCommand;

}
