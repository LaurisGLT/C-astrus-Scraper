
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Scraper.Classes;


namespace Scraper
{
   public class DBCon
    {
        public T Save<T>(T model) where T : class, BaseModel
        {
            using (var context = new DBContext())
            {
                Type type = model.GetType();
                context.Set<T>().Attach(model);
                context.Set<T>().Add(model);
                context.SaveChanges();
                return model;
            }
        }
        public T Update<T>(T model) where T : class, BaseModel
        {
            using (var context = new DBContext())
            {
                Type type = model.GetType();
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
                return model;
            }
        }
        public T Delete<T>(T model) where T : class, BaseModel
        {
            using (var context = new DBContext())
            {
                Type type = model.GetType();
                context.Entry(model).State = EntityState.Deleted;
                context.SaveChanges();
                return model;
            }
        }

        public int Find(string name,bool whatever)
        {
            using (var context = new DBContext())
            {
                if (whatever == true)
                {
                    var test = context.E90Prekes.Where(n => n.product == name);
                    foreach (var preke in test)
                    {
                        if (preke.product.Contains(name))
                        {
                            return preke.Id;
                        }
                        else
                        {

                        }
                    }

                    return 0;
                }
                else
                {
                    var test = context.E60Prekes.Where(n => n.product == name);
                    foreach (var preke in test)
                    {
                        if (preke.product.Contains(name))
                        {
                            return preke.Id;
                        }
                        else
                        {

                        }
                    }

                    return 0;
                }
            }
        }
        










    }
}
