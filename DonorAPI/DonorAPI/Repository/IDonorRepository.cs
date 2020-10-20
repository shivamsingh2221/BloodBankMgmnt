using DonorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonorAPI.Repository
{
   public interface IDonorRepository
    {
        public List<Donor> GetDonors();
        public IQueryable<Donor> GetDonors(int id);
        public Donor PutDonors(int id, Donor donor);
        public void PostDonors(Donor medicine);
        public IQueryable<Donor> DeleteDonors(int id);
    }
}
