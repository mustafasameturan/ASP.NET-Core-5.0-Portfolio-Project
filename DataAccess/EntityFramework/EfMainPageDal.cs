﻿using DataAccess.Abstract;
using DataAccess.GenericRepository;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfMainPageDal : GenericRepository<MainPage>, IMainPageDal
    {
    }
}
