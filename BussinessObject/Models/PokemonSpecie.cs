using System;
using System.Collections.Generic;

namespace DataAccessObject;

public partial class PokemonSpecie
{
    public int Id { get; set; }

    public int NationalNo { get; set; }

    public string? SpecieName { get; set; }

    public int? Type1 { get; set; }

    public int? Type2 { get; set; }

    public int? BaseHp { get; set; }

    public int? BaseAtk { get; set; }

    public int? BaseDef { get; set; }

    public int? BaseSpA { get; set; }

    public int? BaseSpD { get; set; }

    public int? BaseSpe { get; set; }

    public string? Description { get; set; }

    //======================================
    public virtual ICollection<PokemonMove> PokemonMoves { get; set; }
}
