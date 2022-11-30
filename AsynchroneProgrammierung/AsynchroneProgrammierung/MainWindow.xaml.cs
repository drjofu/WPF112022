﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace AsynchroneProgrammierung
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private DispatcherTimer timer;
    private long zähler;
    private object syncObj = new object();

    public MainWindow()
    {
      InitializeComponent();
      timer = new DispatcherTimer();
      timer.Interval = TimeSpan.FromMilliseconds(100);
      timer.Tick += Timer_Tick;
      timer.Start();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
      LBL.Content = zähler;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      //Inkrementieren();
      Task.Run(Inkrementieren);
      //Task.Factory.StartNew(,,TaskCreationOptions.LongRunning)
    }

    private void Inkrementieren()
    {
      for (long i = 0; i < 100_000_000; i++)
      {
        //Monitor.Enter(syncObj);

        lock (syncObj)
        {
          zähler++;
        }

        //Monitor.Exit(syncObj);
      }
    }
  }
}
