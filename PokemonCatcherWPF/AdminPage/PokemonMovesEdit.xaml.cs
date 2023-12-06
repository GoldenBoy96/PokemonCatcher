using BussinessObject.Utils;
using DataAccessObject;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
    /// Interaction logic for PokemonMovesEdit.xaml
    /// </summary>
    public partial class PokemonMovesEdit : Window
    {

        List<PokemonMove> pokemonMoves = new();
        IPokemonService pokemonService;
        PokemonMove pokemonMove;

        public PokemonMovesEdit()
        {
            InitializeComponent();
            pokemonService = App.ServiceProvider.GetService<IPokemonService>();

            txtDamage.Text = "0";
            cmbMoveType.ItemsSource = ConstantLib.MoveTypes;
            cmbMoveType.SelectedIndex = 0;
        }

        public PokemonMovesEdit(PokemonMove pokemonMove)
        {
            InitializeComponent();
            pokemonService = App.ServiceProvider.GetService<IPokemonService>();

            this.pokemonMove = pokemonMove;
            txtMoveName.Text = pokemonMove.MoveName;
            txtDamage.Text = pokemonMove.Damage.ToString();
            cmbMoveType.ItemsSource = ConstantLib.MoveTypes;
            cmbMoveType.SelectedIndex = (int)pokemonMove.MoveType;
            txtDescription.Text = pokemonMove.Description;
        }

        private void cmbMoveType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbMoveType.SelectedValue.Equals(ConstantLib.MoveTypes[2]))
            {
                txtDamage.Text = "0";
            };
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            string validationStatus = FormValidate();
            if (!validationStatus.IsNullOrEmpty())
            {
                MessageBox.Show(validationStatus);
            }
            else
            {

                PokemonMove pokemonMove = new()
                {
                    MoveId = this.pokemonMove.MoveId,
                    MoveName = txtMoveName.Text,
                    Damage = Int32.Parse(txtDamage.Text),
                    MoveType = cmbMoveType.SelectedIndex,
                    Description = txtDescription.Text,

                };
                this.pokemonMove = pokemonMove;
                MessageBox.Show(pokemonMove.ToString());
                pokemonService.UpdatePokemonMove(pokemonMove);

                PokemonMovesManager pokemonMovesManager = Application.Current.Windows.OfType<PokemonMovesManager>().FirstOrDefault(x => x.IsEnabled);
                if (pokemonMovesManager != null)
                {
                    pokemonMovesManager.RefreshWindow();
                }


                this.Close();
            }

        }

        private string FormValidate()
        {
            try
            {
                txtMoveName.Text = txtMoveName.Text.Trim();
                if (txtMoveName.Text.IsNullOrEmpty())
                {
                    return "Move Name can not be blank";
                }
                if (txtMoveName.Text.Length > 30)
                {
                    return "Move Name can not be longer than 30 characters";
                }
                pokemonMoves = pokemonService.GetAllPokemonMove();
                foreach (PokemonMove model in pokemonMoves)
                {
                    if (txtMoveName.Text.Equals(model.MoveName) && !txtMoveName.Text.Equals(this.pokemonMove.MoveName))
                    {
                        return "This Move is existed";
                    }
                }

                if (txtMoveName.Text.IsNullOrEmpty())
                {
                    return "Move Description can not be blank";
                }
                if (txtMoveName.Text.Length > 500)
                {
                    return "Move Description can not be longer than 500 characters";
                }
                if (cmbMoveType.SelectedValue.Equals(ConstantLib.MoveTypes[0]))
                {
                    if (Int32.Parse(txtDamage.Text) == 0)
                    {
                        return "Physical Damage can not be 0";
                    }
                };
                if (cmbMoveType.SelectedValue.Equals(ConstantLib.MoveTypes[1]))
                {
                    if (Int32.Parse(txtDamage.Text) == 0)
                    {
                        return "Special Damage can not be 0";
                    }
                };
            }
            catch
            {
                return "Information is not valid!";
            }
            return string.Empty;
        }
    }
}
