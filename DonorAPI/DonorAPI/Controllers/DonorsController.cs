using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DonorAPI.Models;
using Microsoft.AspNetCore.Authorization;
using DonorAPI.Repository;

namespace DonorAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(DonorsController));
        /*  private readonly inventoryContext _context;

          public DonorsController(inventoryContext context)
          {
              _context = context;
          }
        */
        /*  public DonorsController()
          {
          }
        
     
        */
        
        private IDonorRepository _donorRepository;
        public DonorsController(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        // GET: api/Donors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donor>>> GetDonor()
        {
            _log4net.Info("Controller of DONOR Project");
            return Ok(_donorRepository.GetDonors());
        }


        
        // GET: api/Donors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donor>> GetDonor(int id)
        {
            return Ok(_donorRepository.GetDonors(id));
        }

        // PUT: api/Donors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonor(int id, Donor donor)
        {
            if (id != donor.Id)
            {
                return BadRequest();
            }

            _donorRepository.PutDonors(id,donor);

           

            return NoContent();
        }

        // POST: api/Donors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Donor>> PostDonor(Donor donor)
        {
            _donorRepository.PostDonors(donor);
            return CreatedAtAction("GetDonor", new { id = donor.Id }, donor);
        }

        // DELETE: api/Donors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Donor>> DeleteDonor(int id)
        {
            IQueryable<Donor> donor = (IQueryable<Donor>)_donorRepository.DeleteDonors(id);
            if (donor == null)
            {
                return NotFound();
            }

           
            return Ok(donor);
        }

       
    }
}
