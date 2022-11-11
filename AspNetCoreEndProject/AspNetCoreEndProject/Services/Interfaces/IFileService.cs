using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Services.Interfaces
{
    public interface IFileService
    {
        string ReadFile(string path, string template);
    }
}
