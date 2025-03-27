using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class ServiceRequestController : ControllerBase
    {
        private readonly service_requestContext _context;
        private readonly IMapper _mapper;


        public ServiceRequestController(service_requestContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/ServiceRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceRequest>>> GetServiceRequest()
        {
            var serviceRequests = await _context.ServiceRequest.ToListAsync();
            if (!serviceRequests.Any())
            {
                return NoContent(); // 204 No Content if empty
            }
            return Ok(serviceRequests); // 200 OK
        }

        // GET: api/ServiceRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRequest>> GetServiceRequest(int id)
        {
            var serviceRequest = await _context.ServiceRequest.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(serviceRequest); // 200 OK
        }

        // PUT: api/ServiceRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceRequest(int id, [FromBody] UpdateServiceRequestDto updateServiceRequestDto)
        {
            var serviceRequest = await _context.ServiceRequest.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound(); // 404 Not Found
            }

            // Map only allowed properties (excluding Id)
            _mapper.Map(updateServiceRequestDto, serviceRequest);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceRequestExists(id))
                {
                    return NotFound();  // 404 Not Found
                }
                else
                {
                    throw;
                }
            }

            return Ok(serviceRequest); // Return updated entity
        }

        // POST: api/ServiceRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceRequest>> PostServiceRequest([FromBody] CreateServiceRequestDto serviceRequestDto)
        {

            if (serviceRequestDto == null)
            {
                return BadRequest("Invalid request data."); // 400 Bad Request
            }

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

            return Ok("Service request deleted successfully.");
        }

        private bool ServiceRequestExists(int id)
        {
            return _context.ServiceRequest.Any(e => e.Id == id);
        }
    }
}
