using System;
using System.Collections.Generic;

namespace DataAccessObject;

public partial class Pokemon
{
    public int PokemonId { get; set; }

    public string? PokemonName { get; set; }

    public int? PokemonLevel { get; set; }

    public int? IvHp { get; set; }

    public int? IvAtk { get; set; }

    public int? IvDef { get; set; }

    public int? IvSpA { get; set; }

    public int? IvSpD { get; set; }

    public int? IvSpe { get; set; }

    public int? EvHp { get; set; }

    public int? EvAtk { get; set; }

    public int? EvDef { get; set; }

    public int? EvSpA { get; set; }

    public int? EvSpD { get; set; }

    public int? EvSpe { get; set; }

    public int? Nature { get; set; }

    //======================================
    public virtual ICollection<PokemonMove> PokemonMoves { get; set; }
}
