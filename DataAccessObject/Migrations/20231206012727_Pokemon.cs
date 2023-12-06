using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class Pokemon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    PokemonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PokemonName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PokemonLevel = table.Column<int>(type: "int", nullable: true),
                    IvHp = table.Column<int>(type: "int", nullable: true),
                    IvAtk = table.Column<int>(type: "int", nullable: true),
                    IvDef = table.Column<int>(type: "int", nullable: true),
                    IvSpA = table.Column<int>(type: "int", nullable: true),
                    IvSpD = table.Column<int>(type: "int", nullable: true),
                    IvSpe = table.Column<int>(type: "int", nullable: true),
                    EvHp = table.Column<int>(type: "int", nullable: true),
                    EvAtk = table.Column<int>(type: "int", nullable: true),
                    EvDef = table.Column<int>(type: "int", nullable: true),
                    EvSpA = table.Column<int>(type: "int", nullable: true),
                    EvSpD = table.Column<int>(type: "int", nullable: true),
                    EvSpe = table.Column<int>(type: "int", nullable: true),
                    Nature = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pokemon__69C4E92391505AD7", x => x.PokemonId);
                });

            migrationBuilder.CreateTable(
                name: "PokemonMove",
                columns: table => new
                {
                    MoveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoveName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Damage = table.Column<int>(type: "int", nullable: true),
                    MoveType = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PokemonM__A931A41C48C0241C", x => x.MoveId);
                });

            migrationBuilder.CreateTable(
                name: "PokemonSpecie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalNo = table.Column<int>(type: "int", nullable: false),
                    SpecieName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Type1 = table.Column<int>(type: "int", nullable: true),
                    Type2 = table.Column<int>(type: "int", nullable: true),
                    BaseHp = table.Column<int>(type: "int", nullable: true),
                    BaseAtk = table.Column<int>(type: "int", nullable: true),
                    BaseDef = table.Column<int>(type: "int", nullable: true),
                    BaseSpA = table.Column<int>(type: "int", nullable: true),
                    BaseSpD = table.Column<int>(type: "int", nullable: true),
                    BaseSpe = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PokemonS__E9AA1A64354326FF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonPokemonMove",
                columns: table => new
                {
                    PokemonMovesMoveId = table.Column<int>(type: "int", nullable: false),
                    PokemonsPokemonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonPokemonMove", x => new { x.PokemonMovesMoveId, x.PokemonsPokemonId });
                    table.ForeignKey(
                        name: "FK_PokemonPokemonMove_PokemonMove_PokemonMovesMoveId",
                        column: x => x.PokemonMovesMoveId,
                        principalTable: "PokemonMove",
                        principalColumn: "MoveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonPokemonMove_Pokemon_PokemonsPokemonId",
                        column: x => x.PokemonsPokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "PokemonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonMovePokemonSpecie",
                columns: table => new
                {
                    PokemonMovesMoveId = table.Column<int>(type: "int", nullable: false),
                    PokemonSpeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonMovePokemonSpecie", x => new { x.PokemonMovesMoveId, x.PokemonSpeciesId });
                    table.ForeignKey(
                        name: "FK_PokemonMovePokemonSpecie_PokemonMove_PokemonMovesMoveId",
                        column: x => x.PokemonMovesMoveId,
                        principalTable: "PokemonMove",
                        principalColumn: "MoveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonMovePokemonSpecie_PokemonSpecie_PokemonSpeciesId",
                        column: x => x.PokemonSpeciesId,
                        principalTable: "PokemonSpecie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonMovePokemonSpecie_PokemonSpeciesId",
                table: "PokemonMovePokemonSpecie",
                column: "PokemonSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonPokemonMove_PokemonsPokemonId",
                table: "PokemonPokemonMove",
                column: "PokemonsPokemonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonMovePokemonSpecie");

            migrationBuilder.DropTable(
                name: "PokemonPokemonMove");

            migrationBuilder.DropTable(
                name: "PokemonSpecie");

            migrationBuilder.DropTable(
                name: "PokemonMove");

            migrationBuilder.DropTable(
                name: "Pokemon");
        }
    }
}
