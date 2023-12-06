using BussinessObject.ViewModels;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction
{
    public interface IPokemonService
    {
        bool AddPokemonMove(PokemonMove pokemonMoveViewModel);
        //List<PokemonLearnableMove> GetAllPokemonLearnableMove();
        List<PokemonMove> GetAllPokemonMove();
        List<PokemonSpecie> GetAllPokemonSpecie();
        List<PokemonSpecie> GetAllPokemonSpecieCanLearnMove(int moveId);

        //List<PokemonSpecie> GetAllPokemonSpecieCanLearnMove(int? moveId);
        PokemonMove? GetPokemonMoveById(int? id);
        bool RemovePokemonMove(PokemonMove pokemonMove);
        bool UpdatePokemonMove(PokemonMove pokemonMove);
    }
}
