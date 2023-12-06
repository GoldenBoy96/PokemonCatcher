using DataAccessObject;
using Microsoft.Extensions.DependencyInjection;
using Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PokemonCatcherWPF.AdminPage
{
    /// <summary>
    /// Interaction logic for PokemonSpeciesManager.xaml
    /// </summary>
    public partial class PokemonSpeciesManager : Window
    {
        IPokemonService pokemonService;
        PokemonMove selectedPokemonMove;
        public PokemonSpeciesManager()
        {
            InitializeComponent();
            pokemonService = App.ServiceProvider.GetService<IPokemonService>();
            dgPokemonMoveList.ItemsSource = pokemonService.GetAllPokemonMove();


            //dgPokemonMoveList.Columns[0].Visibility = Visibility.Hidden;

        }
        
        public PokemonSpeciesManager(PokemonMove pokemonMove)
        {
            InitializeComponent();
            pokemonService = App.ServiceProvider.GetService<IPokemonService>();
            MessageBox.Show(pokemonMove.PokemonSpecies + "");
            dgPokemonMoveList.ItemsSource = pokemonMove.PokemonSpecies;


            dgPokemonMoveList.Columns[0].Visibility = Visibility.Hidden;

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            PokemonMovesCreate pokemonMovesCreate = new PokemonMovesCreate();
            pokemonMovesCreate.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPokemonMove == null)
            {
                MessageBox.Show("Must choose an item first");
            }
            else
            {
                PokemonMovesEdit pokemonMovesEdit = new PokemonMovesEdit(selectedPokemonMove);
                pokemonMovesEdit.Show();
            }
        }

        private void dgPokemonMoveList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                selectedPokemonMove = (PokemonMove)dgPokemonMoveList.SelectedItem;
            }
            catch { }
        }



        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPokemonMove == null)
            {
                MessageBox.Show("Must choose an item first");
            }
            else
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    pokemonService.RemovePokemonMove(selectedPokemonMove);
                    RefreshWindow();
                }

            }
        }

        private void Grid_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            dgPokemonMoveList.Items.Refresh();
        }

        private void dgPokemonMoveList_GotFocus(object sender, RoutedEventArgs e)
        {
            dgPokemonMoveList.ItemsSource = pokemonService.GetAllPokemonMove();
            dgPokemonMoveList.Items.Refresh();
        }

        public void RefreshWindow()
        {
            dgPokemonMoveList.ItemsSource = pokemonService.GetAllPokemonMove();
            dgPokemonMoveList.Items.Refresh();
        }
    }
}
