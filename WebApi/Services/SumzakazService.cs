
using Microsoft.EntityFrameworkCore;
using KursProjectISP31.Model;

namespace WebApi.Services
{
    public class SumzakazService : IService<Sumzakaz>
    {
        private readonly GgContext ggContext;
        public SumzakazService(GgContext ggContext)
        {
            this.ggContext = ggContext;
        }

        public async Task<IEnumerable<Sumzakaz>> GetAll()
        {
            return await ggContext.Sumzakazs.ToListAsync();
        }

        

        public async Task Create(Sumzakaz ent)
        {
            ggContext.Sumzakazs.Add(ent); 
            await ggContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var chit = await ggContext.Sumzakazs.FindAsync(id);
            if (chit != null)
            {
                ggContext.Sumzakazs.Remove(chit);
                await ggContext.SaveChangesAsync();
            }
        }

        public async Task Update(Sumzakaz ent)
        {
            ggContext.Entry(ent).State = EntityState.Modified;
            ggContext.Sumzakazs.Update(ent);
            await ggContext.SaveChangesAsync();
        }

        public async Task<Sumzakaz> GetByid(int id)
        {
            return await ggContext.Sumzakazs.FirstAsync(p => p.Idzakaza == id);
        }
    }
}
