using System;
using System.Collections.Generic;

namespace DataAccessObject;

public partial class PokemonMove
{
    public int MoveId { get; set; }

    public string? MoveName { get; set; }

    public int? Damage { get; set; }

    public int? MoveType { get; set; }

    public string? Description { get; set; }

    //======================================
    public virtual ICollection<PokemonSpecie> PokemonSpecies { get; set;}

    public virtual ICollection<Pokemon> Pokemons { get; set; }

}
