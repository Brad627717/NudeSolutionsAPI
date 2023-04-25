using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Data.Entities;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuredItemsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public InsuredItemsController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/InsuredItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuredItemDto>>> GetInsuredItems()
        {
          if (_context.InsuredItems == null)
          {
              return NotFound();
          }
            var insuredItems = await _context.InsuredItems.ToListAsync();
            return _mapper.Map<List<InsuredItemDto>>(insuredItems);
        }

        // GET: api/InsuredItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuredItemDto>> GetInsuredItem(int id)
        {
          if (_context.InsuredItems == null)
          {
              return NotFound();
          }
            var insuredItem = await _context.InsuredItems.FindAsync(id);

            if (insuredItem == null)
            {
                return NotFound();
            }

            return _mapper.Map<InsuredItemDto>(insuredItem);
        }

        // PUT: api/InsuredItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsuredItem(int id, InsuredItemDto insuredItemPayload)
        {
            var updatedInsuredItem = _mapper.Map<InsuredItem>(insuredItemPayload);
            if (id != updatedInsuredItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedInsuredItem).State = EntityState.Modified;

            try
            {
                _context.InsuredItems.Update(updatedInsuredItem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuredItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InsuredItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InsuredItemDto>> PostInsuredItem(InsuredItemDto insuredItemPayload)
        {
          if (_context.InsuredItems == null)
          {
              return Problem("Entity set 'DataContext.InsuredItems'  is null.");
          }
            var newInsuredItem = _mapper.Map<InsuredItem>(insuredItemPayload);
            _context.InsuredItems.Add(newInsuredItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsuredItem", new { id = newInsuredItem.Id }, newInsuredItem);
        }

        // DELETE: api/InsuredItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsuredItem(int id)
        {
            if (_context.InsuredItems == null)
            {
                return NotFound();
            }
            var insuredItem = await _context.InsuredItems.Include(_ => _.Category).Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (insuredItem == null)
            {
                return NotFound();
            }

            _context.InsuredItems.Remove(insuredItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InsuredItemExists(int id)
        {
            return (_context.InsuredItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
