using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.ViewModels
{
    public class PokemonViewModel
    {
        public int PokemonId { get; set; }

        public string? PokemonName { get; set; }

        public int? PokemonLevel { get; set; }

        public int? MaxHp { get; set; }

        public int? CurrentHp { get; set; }

        public int? Atk { get; set; }

        public int? Def { get; set; }

        public int? SpA { get; set; }

        public int? SpD { get; set; }

        public int? Spe { get; set; }

        public string? Nature { get; set; }

        //public List<PokemonMove>? MoveSets {  get; set; } 

        public string? Description { get; set; }
    }
}
