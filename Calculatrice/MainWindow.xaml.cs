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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculatrice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private    string _saisie;
        private       int _resultat;
        private Operateur _operateur;

        public MainWindow()
        {
            InitializeComponent();

            _saisie    = null;
            _resultat  = 0;
            _operateur = Operateur.Rien;
        }

        private void ChiffreButton_Click(object sender, RoutedEventArgs e)
        {
            Button bt      = (Button)sender;
            string chiffre = (string)bt.Content;

            if (_saisie == null || _saisie == "0")
            {
                _saisie = chiffre;
            }
            else
            {
                _saisie = _saisie + chiffre;
            }

            _tb.Text = _saisie;
        }

        private void OperateurButton_Click(object sender, RoutedEventArgs e)
        {
            Button bt        = (Button)sender;
            string operateur = (string)bt.Content;

            // Calcul de la dernière opération.
            if (_saisie != null)
            {
                int v = int.Parse(_saisie);
                switch (_operateur)
                {
                    case Operateur.Rien:
                        _resultat = v;
                        break;

                    case Operateur.Plus:
                        _resultat = _resultat + v;
                        break;

                    case Operateur.Moins:
                        _resultat = _resultat - v;
                        break;

                    case Operateur.Mult:
                        _resultat = _resultat * v;
                        break;

                    case Operateur.Div when v != 0:
                        _resultat = _resultat / v;
                        break;

                    case Operateur.Div: // when v == 0
                        MessageBox.Show("Division par zéro");
                        return; // Quitte la fonction.
                }
            }

            switch (operateur)
            {
                case "=":
                    _operateur = Operateur.Rien;                   
                    break;

                case "+":
                    _operateur = Operateur.Plus;
                    break;

                case "-":
                    _operateur = Operateur.Moins;
                    break;

                case "*":
                    _operateur = Operateur.Mult;
                    break;

                case "/":
                    _operateur = Operateur.Div;
                    break;
            }

            _saisie  = null;
            _tb.Text = _resultat.ToString();
        }
    }

    public enum Operateur
    {
        Rien, Plus, Moins, Mult, Div
    }
}
