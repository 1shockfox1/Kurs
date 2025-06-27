using KursProjectISP31.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProjectISP31.Services
{
    internal class SumzakazService : BaseService<Sumzakaz>

    {
        public override bool Add(Sumzakaz obj)
        {
           using (GgContext db = new GgContext())
            {
                db.Sumzakazs.Add(obj);
                db.SaveChangesAsync();
            }
           return true;
        }
        public override bool Delete(Sumzakaz obj)
        {
            using (GgContext db = new GgContext())
            {
                db.Sumzakazs.Remove(obj);
                db.SaveChangesAsync();
            }
            return true;
        }
        public override List<Sumzakaz> GetAll()
        {
            using (GgContext db = new GgContext())
            {
                return db.Sumzakazs.ToList();
            }
        }
        public override bool Update(Sumzakaz obj)
        {
            using (GgContext db = new GgContext())
            {
                db.Sumzakazs.Update(obj);
                db.SaveChangesAsync();
            }
            return true;
        }
        public override List<Sumzakaz> Search(string str)
        {
            using (GgContext db = new GgContext())
            {
                return db.Sumzakazs.Where(p => p.Datazakaza!.StartsWith(str) ||
                    p.Client.ToString().StartsWith(str)).ToList();
            }

        }
    }
}
