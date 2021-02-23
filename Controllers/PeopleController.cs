using Microsoft.AspNetCore.Mvc;
using People.API.Models;
using People.API.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IDataRepository<Person> persons;

        public PeopleController(IDataRepository<Person> persons)
        {
            this.persons = persons;
        }

        // GET: api/People
        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            return await persons.GetItemsAsync();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/People/5
        [HttpGet("{id}")]//, Name = "Get")]
        public async Task<IActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            else
            {
                var person = await persons.GetItemAsync(id);

                if (person != null)
                {
                    return Ok(person);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        // POST: api/People
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            // Copy data
            var item = new Person
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                BirthDate = person.BirthDate,
                Description = person.Description
            };

            // Assign ID
            if (string.IsNullOrEmpty(person.Id))
            {
                item.Id = Guid.NewGuid().ToString();
            }

            await persons.AddItemAsync(item);

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, null);
        }

        // PUT: api/People/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Person person)
        {
            var item = await persons.GetItemAsync(person.Id);

            if (item == null)
            {
                return NotFound(new
                {
                    Message = $"Person with id " +
                    $"{ person.Id}" + " not found"
                });
            }

            await persons.UpdateItemAsync(person);

            return CreatedAtAction(nameof(GetById), 
                new { id = person.Id }, null);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var item = await persons.GetItemAsync(id);

            if(item == null)
            {
                return NotFound();
            }

            await persons.DeleteItemAsync(id);

            return NoContent();
        }
    }
}
