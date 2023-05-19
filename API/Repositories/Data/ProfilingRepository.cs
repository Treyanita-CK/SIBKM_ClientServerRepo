﻿using API.Context;
using API.Models;
using API.Repositories.Interfaces;
namespace API.Repositories.Data
{
    public class ProfilingRepository :
        GeneralRepository<Profiling, string, MyContext>, IProfilingRepository
    {
        public ProfilingRepository(MyContext context) : base(context) { }
    

    }
}
