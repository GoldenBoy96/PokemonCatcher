using DataAccessObject;
using Repository.GenericRepository;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class PokemonRepository : GenericRepository<Pokemon>, IPokemonRepository
    {
        public PokemonRepository() : base()
        {
        }
    }
}
