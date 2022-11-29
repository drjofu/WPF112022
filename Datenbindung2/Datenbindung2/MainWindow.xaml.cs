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

namespace Datenbindung2
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      this.DataContext = new Firma();
    }

    private void DieJahreVergehen(object sender, RoutedEventArgs e)
    {
      var liste = ((Firma)DataContext).Mitarbeiter;
      foreach (var mitarbeiter in liste)
      {
        mitarbeiter.Alter++;
      }
    }

    private void NeuerMitarbeiter(object sender, RoutedEventArgs e)
    {
      var liste = ((Firma)DataContext).Mitarbeiter;     
      liste.Add(new() { Name = "Der Neue", Wohnort = "irgendwo", Alter = 20 });
    }
  }
}
