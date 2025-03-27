using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using service_request.Data;
using service_request.Dtos;
using service_request.Models;

namespace service_request.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly service_requestContext _context;

        public ServiceRequestsController(service_requestContext context)
        {
            _context = context;
        }

        // GET: api/ServiceRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceRequest>>> GetServiceRequest()
        {
            return await _context.ServiceRequest.ToListAsync();
        }

        // GET: api/ServiceRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRequest>> GetServiceRequest(int id)
        {
            var serviceRequest = await _context.ServiceRequest.FindAsync(id);

            if (serviceRequest == null)
            {
                return NotFound();
            }

            return serviceRequest;
        }

        // PUT: api/ServiceRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceRequest(int id, ServiceRequest serviceRequest)
        {
            if (id != serviceRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceRequestExists(id))
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

        // POST: api/ServiceRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceRequest>> PostServiceRequest(CreateServiceRequestDto serviceRequestDto)
        {
            _context.ServiceRequest.Add(serviceRequestDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceRequest", new { id = serviceRequestDto.Id }, serviceRequestDto);
        }

        // DELETE: api/ServiceRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceRequest(int id)
        {
            var serviceRequest = await _context.ServiceRequest.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound();
            }

            _context.ServiceRequest.Remove(serviceRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceRequestExists(int id)
        {
            return _context.ServiceRequest.Any(e => e.Id == id);
        }
    }
}
