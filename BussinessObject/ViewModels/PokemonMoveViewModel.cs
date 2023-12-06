using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.ViewModels
{
    public class PokemonMoveViewModel
    {
        public string? MoveName { get; set; }

        public int? Damage { get; set; }

        public string? MoveType { get; set; }

        public string? Description { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(MoveName)}={MoveName}, {nameof(Damage)}={Damage.ToString()}, {nameof(MoveType)}={MoveType}, {nameof(Description)}={Description}}}";
        }
    }
}
