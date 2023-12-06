using AutoMapper;
using BussinessObject.ViewModels;
using DataAccessObject;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using Repository.Repository;
using Repository.UnitOfWork;
using Service.Abstraction;
using System.Collections.Generic;

namespace Service.Implement
{
    public class PokemonService : IPokemonService
    {
        private IPokemonMoveRepository pokemonMoveRepository;
        private IPokemonRepository pokemonRepository;
        private IPokemonSpecieRepository pokemonSpecieRepository;
        private readonly IMapper mapper;


        public PokemonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.pokemonMoveRepository = unitOfWork.PokemonMoveRepository;
            this.pokemonRepository = unitOfWork.PokemonRepository;
            this.pokemonSpecieRepository = unitOfWork.PokemonSpecieRepository;
            this.mapper = mapper;
        }

        public bool AddPokemonMove(PokemonMove pokemonMove)
        {

            return pokemonMoveRepository.Add(pokemonMove);
        }

        //public  List<PokemonMove> GetAllPokemonMove()
        //{
        //    return (List<PokemonMove>) pokemonMoveRepository.GetAll();
        //}
        public List<PokemonMove> GetAllPokemonMove()
        {
            List<PokemonMove> pokemonMoves = (List<PokemonMove>)pokemonMoveRepository.GetAll();
            return pokemonMoves;
        }


        public PokemonMove? GetPokemonMoveById(int? id)
        {

            return pokemonMoveRepository.GetById(id);
        }

        //public List<PokemonSpecie> GetAllPokemonSpecieCanLearnMove(int? moveId)
        //{
        //    try
        //    {
        //        //List<PokemonLearnableMove>? pokemonLearnableMoves = pokemonLearnableMoveRepository.GetByPokemonMoveId((int)moveId);
        //        List<PokemonLearnableMove>? pokemonLearnableMoves = (List<PokemonLearnableMove>?)pokemonLearnableMoveRepository.GetAll();
        //        if (pokemonLearnableMoves != null)
        //        {
        //            List < PokemonSpecie > pokemonSpecie = new List<PokemonSpecie>();
        //            foreach(var move in pokemonLearnableMoves)
        //            {
        //                pokemonSpecie.Add(move.NationalNoNavigation);
        //            }
        //            return pokemonSpecie;
        //        }
        //        else
        //        {
        //            return new();

        //        }
        //    }
        //    catch
        //    {
        //        return new();

        //    }

        //}

        public bool RemovePokemonMove(PokemonMove pokemonMove)
        {
            return pokemonMoveRepository.Remove(pokemonMove);
        }

        public bool UpdatePokemonMove(PokemonMove pokemonMove)
        {
            return pokemonMoveRepository.Update(pokemonMove);
        }

        //public bool AddPokemonMove(PokemonMove pokemonMove)
        //{

        //    return pokemonMoveRepository.Add(pokemonMove);
        //}

        public List<PokemonSpecie> GetAllPokemonSpecie()
        {
            return (List<PokemonSpecie>)pokemonSpecieRepository.GetAll();
        }

        public List<PokemonSpecie> GetAllPokemonSpecieCanLearnMove(int moveId)
        {
            throw new NotImplementedException();
        }

        //public PokemonMove? GetPokemonMoveById(int? id)
        //{

        //    return pokemonMoveRepository.GetById(id);
        //}

        //public bool RemovePokemonMove(PokemonMove pokemonMove)
        //{
        //    return pokemonMoveRepository.Remove(pokemonMove);
        //}

        //public bool UpdatePokemonMove(PokemonMove pokemonMove)
        //{
        //    return pokemonMoveRepository.Update(pokemonMove);
        //}

        //public List<PokemonLearnableMove> GetAllPokemonLearnableMove()
        //{
        //    return pokemonLearnableMoveRepository.GetAll();
        //}

    }




}


