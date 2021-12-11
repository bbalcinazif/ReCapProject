﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities.Concrete
{
   
    public class Customer:IEntity
    {
        
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
