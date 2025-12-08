using KursClientChoco.Model;
using KursClientChoco.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursClientChoco.Services
{
    public class KomponentService : BaseService<Komponent>

    {
        public override bool Add(Komponent obj)
        {
            using (GgContext db = new GgContext()) {
                db.Komponents.Add(obj);
                db.SaveChangesAsync();
            }
            return true ;
        }

        public override bool Delete(Komponent obj)
        {
            using (GgContext db = new GgContext())
            {
                db.Komponents.Remove(obj);
                db.SaveChangesAsync();
            }
            return true;
        }

        public override List<Komponent> GetAll()
        {
            using (GgContext db = new GgContext())
            {
              return  db.Komponents.ToList();
            }
           
        }

        public override bool Update(Komponent obj)
        {
            using (GgContext db = new GgContext())
            {
                db.Komponents.Update(obj);
                db.SaveChangesAsync();
            }
            return true;
        }

        public override List<Komponent> Search(string str)
        {
            using (GgContext db = new GgContext())
            {
                return db.Komponents.Where(p => p.Namekomp!.StartsWith(str)).ToList();
            }
        }
    }
}
