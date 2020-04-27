using Demo.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Demo.API.Manager
{
    public class BeatleManager
    {
        private List<Beatle> _beatles;

        public BeatleManager()
        {
            _beatles = new List<Beatle>
            {
                new Beatle() { Id = 1, FirstName = "John", LastName = "Lennon" },
                new Beatle() { Id = 2, FirstName = "Paul", LastName = "McCartney" },
                new Beatle() { Id = 3, FirstName = "George", LastName = "Harrison" },
                new Beatle() { Id = 4, FirstName = "Ringo", LastName = "Starr" }
            };
        }

        public List<Beatle> GetAll()
        {
            return _beatles;
        }

        public Beatle GetById(int id)
        {
            return _beatles.First(x => x.Id == id);
        }
    }
}