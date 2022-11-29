using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Datenbindung2
{
  class NotificationObject : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }

  class Person : NotificationObject
  {
    public string Name { get; set; }
    public string Wohnort { get; set; }
    //public int Alter { get; set; }
    private int alter;

    public int Alter
    {
      get { return alter; }
      set
      {
        if (alter == value) return;  // falls erforderlich, erst prüfen

        alter = value;
        OnPropertyChanged();
        OnPropertyChanged(nameof(IstErfahren));
      }
    }

    public bool IstErfahren => Alter > 50;

  }

  class Firma : NotificationObject
  {
    public string Name { get; set; } = "Hintz & Kuntz";
    public ObservableCollection<Person> Mitarbeiter { get; set; } = new ObservableCollection<Person>()
    {
      new (){Name="Petra", Wohnort="Köln", Alter=44},
      new (){Name="Marie", Wohnort="Ulm", Alter=37 },
      new (){Name="Karin", Wohnort="Hamburg", Alter=44},
      new (){Name="Uwe", Wohnort="Köln", Alter=54},
      new (){Name="Klaus", Wohnort="München",Alter=66}
    };
  }
}
