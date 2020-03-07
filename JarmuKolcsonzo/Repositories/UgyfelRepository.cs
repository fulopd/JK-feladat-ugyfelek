using JarmuKolcsonzo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarmuKolcsonzo.Repositories
{
    public class UgyfelRepository : IDisposable
    {
        private JKContext db = new JKContext();
        private int _totalItems;

        public BindingList<ugyfel> GetAllUgyfel(
            int page = 0,
            int itemsPerPage = 0,
            string search = null,
            string sortBy = null,
            bool ascending = true)
        {
            var query = db.ugyfel.OrderBy(x => x.id).AsQueryable();

            // TODO: Keresés
            // Keresés
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                int irszam;
                int.TryParse(search, out irszam);

                query = query.Where(x => x.vezeteknev.ToLower().Contains(search) ||
                                        x.irszam.Equals(irszam));
            }

            // TODO: Sorbarendezés
            // Sorbarendezés
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                switch (sortBy)
                {
                    default:
                        query = ascending ? query.OrderBy(x => x.id) : query.OrderByDescending(x => x.id);
                        break;
                }
            }

            // Összes találat kiszámítása
            _totalItems = query.Count();

            // Oldaltördelés
            if (page + itemsPerPage > 0)
            {
                query = query.Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
            }

            return new BindingList<ugyfel>(query.ToList());
        }

        public int Count()
        {
            return _totalItems;
        }

        public void Insert(ugyfel uf)
        {
            // TODO: Beillesztés
        }

        public void Delete(int id)
        {
            var ugyfel = db.ugyfel.Find(id);
            // TODO: Törlés
        }

        public void Update(ugyfel param)
        {
            var uf = db.ugyfel.Find(param.id);
            if (uf != null)
            {
                db.Entry(uf).CurrentValues.SetValues(param);
            }
        }

        public bool Exists(ugyfel uf)
        {
            return db.ugyfel.Any(x => x.id == uf.id);
        }

        public void Save()
        {
            // TODO: Mentés
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}
