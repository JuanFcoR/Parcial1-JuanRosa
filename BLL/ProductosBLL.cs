﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcial1_JuanRosa.Entidades;
using Parcial1_JuanRosa.DAL;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Parcial1_JuanRosa.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(Productos Producto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Productos.Add(Producto)!=null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception)
            {

                throw;
            }
            

            return paso;
        }

        public static bool Modificar(Productos Producto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(Producto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Productos Producto = contexto.Productos.Find(id);
                contexto.Productos.Remove(Producto);
                paso = contexto.SaveChanges() > 0;
                contexto.Dispose();
            }
            
            catch (Exception)
            {

                throw;
            }
            
            return paso;
        }

        public static Productos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Productos Producto;
            try
            {
                Producto = contexto.Productos.Find(id);
                contexto.Dispose();
            }
           
            catch (Exception)
            {

                throw;
            }

            return Producto;
        }

        public static List<Productos> GetList(Expression<Func<Productos, bool>> expression)
        {
            List<Productos> Producto = new List<Productos>();
            Contexto contexto = new Contexto();

            try
            {
                contexto.Productos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return Producto;
        }

    }
}
