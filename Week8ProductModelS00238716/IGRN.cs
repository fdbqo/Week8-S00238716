﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModel
{
    public interface IGRN<T> : IRepository<T> where T : GRN
    {
       
    }
}
