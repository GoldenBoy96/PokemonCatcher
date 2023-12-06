using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCatcherWPF.AdminPage
{
    public class DataHandler
    {
        private DataHandler() { }
        private static DataHandler _instance;
        public static DataHandler GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHandler();
            }
            return _instance;
        }
        
        private List<PokemonMove> moves = new List<PokemonMove>();

        public List<PokemonMove> Moves { get => moves; set => moves = value; }
    }
}
