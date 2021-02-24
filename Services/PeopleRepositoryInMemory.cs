using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.API.Models;

namespace People.API.Services
{
    public class PeopleRepositoryInMemory : IDataRepository<Person>
    {
        protected readonly List<Person> items;

        public PeopleRepositoryInMemory()
        {
            items = new List<Person>
            {
                new Person {Id = "0", FirstName="David", LastName="Duchovny",
                    BirthDate = new DateTime(1962, 05, 12), Description="Actor" },

                new Person {Id = "1", FirstName="Dawid", LastName="Borycki",
                    BirthDate = new DateTime(1982, 12, 18), Description="Trainer" },

                new Person {Id = "2", FirstName="Albert", LastName="Einstein",
                    BirthDate = new DateTime(1912, 11, 18), Description="Scientist" },

                new Person {Id = "3", FirstName="Michel", LastName="Jackson",
                    BirthDate = new DateTime(1912, 11, 18), Description="Musician" },

                new Person {Id = "4", FirstName="Robert", LastName="Lewandowski",
                    BirthDate = new DateTime(1912, 11, 18), Description="Sportsman" },
            };
        }

        public async Task<bool> AddItemAsync(Person item)
        {
            items.Add(item);

            return await Task.FromResult(true);
            //throw new NotImplementedException();
        }       

        public async Task<Person> GetItemAsync(string id)
        {
            var item = items.FirstOrDefault(p => p.Id == id);

            return await Task.FromResult(item);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Person>> GetItemsAsync()
        {
            return await Task.FromResult(items);
            //throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(Person item)
        {
            //throw new NotImplementedException();
            var itemToUpdate = items.FirstOrDefault(p => p.Id == item.Id);

            items.Remove(itemToUpdate);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var itemToRemove = items.Find(p => p.Id == id);

            if(itemToRemove != null)
            {
                var isRemoved = items.Remove(itemToRemove);

                return await Task.FromResult(isRemoved);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }
    }
}
