using System.Collections.Generic;

namespace Datenbindung2
{
  class Person
  {
    public string Name { get; set; }
    public string Wohnort { get; set; }
    public int Alter { get; set; }

    public bool IstErfahren => Alter > 50;
  }

  class Firma
  {
    public string Name { get; set; } = "Hintz & Kuntz";
    public List<Person> Mitarbeiter { get; set; } = new List<Person>()
    {
      new (){Name="Petra", Wohnort="Köln", Alter=44},
      new (){Name="Marie", Wohnort="Ulm", Alter=37 },
      new (){Name="Karin", Wohnort="Hamburg", Alter=44},
      new (){Name="Uwe", Wohnort="Köln", Alter=54},
      new (){Name="Klaus", Wohnort="München",Alter=66}
    };
  }
}
