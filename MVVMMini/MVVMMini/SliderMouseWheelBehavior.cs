using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVVMMini
{
  internal class SliderMouseWheelBehavior : Behavior<Slider>
  {
    protected override void OnAttached()
    {
      base.OnAttached();
      this.AssociatedObject.MouseWheel += AssociatedObject_MouseWheel;
    }

    protected override void OnDetaching()
    {
      this.AssociatedObject.MouseWheel -= AssociatedObject_MouseWheel;
      base.OnDetaching();
    }

    private void AssociatedObject_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
    {
      this.AssociatedObject.Value += e.Delta * this.AssociatedObject.SmallChange;
    }
  }
}
