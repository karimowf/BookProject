﻿using DATA.Data.Entity;
using DATA.Data;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BookDbContext context) : base(context)
        {

        }
    }
}