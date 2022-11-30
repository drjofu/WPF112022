using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace AsynchroneProgrammierung
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class Window1 : Window
  {
    private CancellationTokenSource cts;
    private CancellationToken ct;

    public Window1()
    {
      InitializeComponent();
    }

    private async void BTN_Start_Click(object sender, RoutedEventArgs e)
    {
      cts = new CancellationTokenSource();
      ct = cts.Token;

      BTN_Start.IsEnabled = false;
      //Task
      //  .Run(Inkrementieren)
      //  .ContinueWith(t => BTN_Start.IsEnabled = true,TaskScheduler.FromCurrentSynchronizationContext());

      Task t = Task.Run(Inkrementieren, ct);

      try
      {
        await t;
      }
      catch (Exception ex)
      {
      }

      //await Task.WhenAll(t);
      BTN_Start.IsEnabled = true;
      //await Task.Run(...)
      try
      {
        var n = await Zwischenschritt();
        LBL.Content = n;
      }
      catch (Exception)
      {
      }
    }

    private Task<int> Zwischenschritt()
    {
      return AntwortAufDieFrageAllerFragen();
    }

    private async Task<int> AntwortAufDieFrageAllerFragen()
    {
      await Task.Delay(5000, ct);
      return 42;
    }

    private void Inkrementieren()
    {
      int i;
      for (i = 0; i < 5; i++)
      {
        if (ct.IsCancellationRequested)
        {
          // aufräumen...
          ct.ThrowIfCancellationRequested();
        }

        int k = i;
        Thread.Sleep(1000);
        //LBL.Content = i;
        //Dispatcher.BeginInvoke(() => LBL.Content = i);
        Dispatcher.BeginInvoke(() => LBL.Content = k);
        //Dispatcher.BeginInvoke(() => Debug.WriteLine(k));  // Closure
      }
    }

    private void BTN_Stopp_Click(object sender, RoutedEventArgs e)
    {
      cts.Cancel();
    }
  }
}
