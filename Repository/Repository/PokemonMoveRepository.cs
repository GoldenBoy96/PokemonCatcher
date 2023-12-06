using DataAccessObject;
using Microsoft.EntityFrameworkCore;
using Repository.GenericRepository;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class PokemonMoveRepository : GenericRepository<PokemonMove>, IPokemonMoveRepository
    {
        public PokemonMoveRepository() : base()
        {
        }

        public new List<PokemonMove> GetAll()
        {
            return _context.PokemonMoves.AsNoTracking().Include(o => o.PokemonSpecies).ToList();
        }

        public new PokemonMove? GetById(int? id)
        {
            return _context.PokemonMoves.AsNoTracking().Where(x => x.MoveId == id).Include(o => o.PokemonSpecies).FirstOrDefault();
        }

        public new bool Remove(PokemonMove pokemonMove)
        {
            if (pokemonMove != null)
            {
                foreach (var item in pokemonMove.PokemonSpecies)
                {
                    _context.Database.ExecuteSql($"DELETE FROM [dbo].[PokemonMovePokemonSpecie] WHERE PokemonMovesMoveId={pokemonMove.MoveId} AND PokemonSpeciesId={item.Id}");
                    pokemonMove.PokemonSpecies.Remove(item);
                }
                
            }
            _dbSet.Remove(pokemonMove);
            int success = _context.SaveChanges();
            return success == 1;
        }


    }
}
