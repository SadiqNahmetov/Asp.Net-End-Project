using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Services.Interfaces
{

    public interface IEmailService
    {
        void Send(string to, string subject, string body, string from = null);

    }
}
