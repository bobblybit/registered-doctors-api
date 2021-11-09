using RegisteredDoctors.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisteredDoctors.Services.Interface
{
    public interface IDoctor
    {
        public Task<RegisteredDoctor> GetDoctorAsync(string regNumb);
    }
}
