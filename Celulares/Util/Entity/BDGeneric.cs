using Celulares.Util.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;


namespace Celulares.Util.Entity
{
    public class BDGeneric<T> where T : DBable
    {
        public  DbSet<T> Dbset { get; set; }
        private DbContext context;
        private Type classType;

        public  BDGeneric(DbContext context, DbSet<T> dbset)
        {
            this.context = context;
            Dbset = dbset;
            classType = typeof(T);
        }

        public void Remove(T type, bool isEliminadoFisico = false)
        {
            var elemento_a_eliminar = Dbset.Find(type.Id);
            if (elemento_a_eliminar == null) return;
            if (!isEliminadoFisico)
            {
                elemento_a_eliminar.Eliminado = true;
                Alter(elemento_a_eliminar);
            }
            else
            {
                elemento_a_eliminar.FechaCreacion = DateTime.Now;
                elemento_a_eliminar.FechaModificacion = DateTime.Now;
                elemento_a_eliminar.Actividades.Add(new Actividad { FechaActividad = DateTime.Now, Nombre = GetEnumDescription(TipoActividad.EliminadoFisico), Extra = classType.Name });
                Dbset.Remove(elemento_a_eliminar);
                context.SaveChanges();
            }
        }

        public List<T> ToList(bool incluyeEliminadoLogico = false)
        {
            var res = Dbset.ToList();
            if (res == null) return new List<T>();
            List<T> ans = new List<T>();
            foreach (var item in res)
                if (incluyeEliminadoLogico)
                {
                    ans.Add(item);
                }
                else
                {
                    if (!item.Eliminado)
                    {
                        ans.Add(item);
                    }
                }
            return ans;
        }

        public List<T> Where(Func<T, bool> predicate, bool incluyeEliminadoLogico = false)
        {
            try
            {
                return Dbset.Where(predicate).Where(p => !p.Eliminado || incluyeEliminadoLogico).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public T One(Func<T, bool> predicate, bool incluyeEliminadoLogico = false)
        {
            try
            {
                return Dbset.Where(predicate).Where(p => !p.Eliminado || incluyeEliminadoLogico).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Any(Func<T, bool> predicate, bool incluyeEliminadoLogico = false)
        {
            try
            {
                return Dbset.Where(predicate).Where(p => !p.Eliminado || incluyeEliminadoLogico).Count() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T Find(int Id, bool incluyeEliminadoLogico = true)
        {
            try
            {
                var a = Dbset.Find(Id);
                if (a.Eliminado && !incluyeEliminadoLogico) return null;
                return a;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Alter(T camposCambiados)
        {
            if (!(camposCambiados.Id >= 1))
                throw new Exception("El campo Id no puede ser null");

            var elemento_db = Dbset.Find(camposCambiados.Id);
            elemento_db.FechaCreacion = DateTime.Now;
            elemento_db.FechaModificacion = DateTime.Now;
            elemento_db.Actividades.Add(new Actividad { FechaActividad = DateTime.Now, Nombre = GetEnumDescription(TipoActividad.Modificado), Extra = classType.Name });

            if (elemento_db == null) throw new Exception("No existe el Id en la BD");
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(camposCambiados))
            {
                if (!property.Name.Equals("Id") && property.GetValue(camposCambiados) != null)
                {
                    property.SetValue(elemento_db, property.GetValue(camposCambiados));
                }
            }
            context.Entry(elemento_db).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public int Add(T element)
        {
            element.FechaCreacion = DateTime.Now;
            element.FechaModificacion = DateTime.Now;
            element.Actividades.Add(new Actividad { FechaActividad = DateTime.Now, Nombre = GetEnumDescription(TipoActividad.Agregado), Extra = classType.Name });
            Dbset.Add(element);
            context.SaveChanges();
            return element.Id;
        }

        public List<T> Include(string predicate, bool incluyeEliminadoLogico = false)
        {
            try
            {
                var a = Dbset.Include(predicate).Where(p => !p.Eliminado || incluyeEliminadoLogico).ToList();
                return a;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static String GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}