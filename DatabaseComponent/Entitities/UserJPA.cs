﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseComponent.Entitities;
    public class UserJPA
{

    public Guid ID { get; set; }
    public string UserName { get; set; }

    public string Password { get; set; }
}

