using DataAccessObject;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(IPokemonMoveRepository pokemonMoveRepository, IPokemonRepository pokemonRepository, IPokemonSpecieRepository pokemonSpecieRepository)
        {
            PokemonMoveRepository = pokemonMoveRepository;
            PokemonRepository = pokemonRepository;
            PokemonSpecieRepository = pokemonSpecieRepository;
        }

        public IPokemonMoveRepository PokemonMoveRepository { get; }

        public IPokemonRepository PokemonRepository { get; }

        public IPokemonSpecieRepository PokemonSpecieRepository { get; }

        
    }
}
