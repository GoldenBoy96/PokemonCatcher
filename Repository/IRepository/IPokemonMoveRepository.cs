using DataAccessObject;
using Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IPokemonMoveRepository : IGenericRepository<PokemonMove>
    {
        List<PokemonMove> GetAll();
        PokemonMove? GetById(int? id);
        bool Remove(PokemonMove pokemonMove);
    }
}
