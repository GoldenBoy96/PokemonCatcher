using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.ViewModels
{
    public class PokemonSpecieViewModel
    {
        public int NationalNo { get; set; }

        public string? SpecieName { get; set; }

        public int? BaseHp { get; set; }

        public int? BaseAtk { get; set; }

        public int? BaseDef { get; set; }

        public int? BaseSpA { get; set; }

        public int? BaseSpD { get; set; }

        public int? BaseSpe { get; set; }

        //public List<PokemonMove>? LearnableMoves { get; set; }
    }
}
