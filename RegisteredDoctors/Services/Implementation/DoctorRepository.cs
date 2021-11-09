using RegisteredDoctors.Data;
using RegisteredDoctors.Data.Models;
using RegisteredDoctors.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisteredDoctors.Services.Implementation
{
    public class DoctorRepository : IDoctor
    {
        private readonly RegisteredDoctorsContext _ctx;

        public DoctorRepository(RegisteredDoctorsContext ctx)
        {
            _ctx = ctx;
        }


        public async Task<RegisteredDoctor> GetDoctorAsync(string regNumb)
        {
            return _ctx.registeredDoctors.FirstOrDefault(x => x.ResgitrationNumber == regNumb);

        }
    }
}
