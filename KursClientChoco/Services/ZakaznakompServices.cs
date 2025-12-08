using KursClientChoco.Model;
using KursClientChoco.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProjectISP31.Services
{
    class ZakaznakompServices : BaseService<Zakaznakomp>
    {

        public override bool Add(Zakaznakomp obj)
        {
            using (GgContext db = new GgContext())
            {
                db.Zakaznakomps.Add(obj);
                db.SaveChangesAsync();
            }
            return true;
        }
        public override bool Delete(Zakaznakomp obj)
        {
            using (GgContext db = new GgContext())
            {
                db.Zakaznakomps.Remove(obj);
                db.SaveChangesAsync();
            }
            return true;
        }
        public override List<Zakaznakomp> GetAll()
        {
            using (GgContext db = new GgContext())
            {
                return db.Zakaznakomps.ToList();
            }
        }
        public override bool Update(Zakaznakomp obj)
        {
            using (GgContext db = new GgContext())
            {
                db.Zakaznakomps.Update(obj);
                db.SaveChangesAsync();
            }
            return true;
        }
        public override List<Zakaznakomp> Search(string str)
        {
            using (GgContext db = new GgContext())
            {
                return db.Zakaznakomps.Where(p => p.Post!.StartsWith(str) ||
                p.Statyspost!.StartsWith(str)).ToList();
            }
        }
    }
}
