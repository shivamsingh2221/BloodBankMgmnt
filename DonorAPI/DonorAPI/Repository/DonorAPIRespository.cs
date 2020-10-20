using DonorAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonorAPI.Repository
{
    public class DonorAPIRespository : IDonorRepository
    {
        private readonly inventoryContext _context;

        public DonorAPIRespository(inventoryContext context)
        {
            _context = context;
        }



        public IQueryable<Donor> DeleteDonors(int id)
        {

           //   _context.Donor.FindAsync(id);
            IQueryable<Donor> donor= _context.Donor.Where( a => a.Id == id );

            _context.Donor.Remove(donor.FirstOrDefault());
               _context.SaveChangesAsync();

            return donor;
        }

        public List<Donor> GetDonors()
        {
            return _context.Donor.ToList();
        }

        public IQueryable<Donor> GetDonors(int id)
        {
            return _context.Donor.Where(a => a.Id == id);
        }

        public void PostDonors(Donor donor)
        {
            _context.Donor.Add(donor);
            _context.SaveChangesAsync();
        }

        public Donor PutDonors(int id, Donor donor)
        {
            _context.Entry(donor).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return donor;
        }
    }
}
