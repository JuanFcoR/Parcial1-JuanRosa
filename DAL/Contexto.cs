﻿using Parcial1_JuanRosa.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_JuanRosa.DAL
{
    public class Contexto:DbContext
    {
        DbSet<Productos> Productos { get; set; }

        public Contexto():base("ConStr")
        {

        }
    }
}