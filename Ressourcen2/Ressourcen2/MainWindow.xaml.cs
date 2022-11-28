﻿using System;
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

namespace Ressourcen2
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      var brush = (LinearGradientBrush)Resources["LGB"];
      brush.GradientStops[0].Color = Colors.Red;
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      Resources["LGB"] = new LinearGradientBrush(Colors.Orange, Colors.Pink, 30);
    }
  }
}
