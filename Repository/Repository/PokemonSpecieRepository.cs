using DataAccessObject;
using Microsoft.EntityFrameworkCore;
using Repository.GenericRepository;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class PokemonSpecieRepository : GenericRepository<PokemonSpecie>, IPokemonSpecieRepository
    {
        public PokemonSpecieRepository() : base()
        {
        }

        

        //public new List<PokemonSpecie> GetAll()
        //{
        //    //return _dbSet.AsNoTracking().Include(o => o.LearnableMoves).ToList();
        //}

        //public T? GetById(int? id)
        //{

        //    return _dbSet.Find(id);
        //}
    }
}
