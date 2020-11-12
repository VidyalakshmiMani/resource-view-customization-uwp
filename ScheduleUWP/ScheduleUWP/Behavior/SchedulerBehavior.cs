using Syncfusion.UI.Xaml.Schedule;
using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml;

namespace ScheduleUWP
{
    public class SchedulerBehavior : Behavior<SfSchedule>
    {
        SfSchedule schedule;

        protected override void OnAttached()
        {
            base.OnAttached();
            schedule = this.AssociatedObject;
            this.AssociatedObject.SizeChanged += Schedule_SizeChanged;
        }

        private void Schedule_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            schedule.IntervalHeight = e.NewSize.Width / 5;
        }
        protected override void OnDetaching()
        {
            if (schedule != null)
            {
                base.OnDetaching();
                this.AssociatedObject.SizeChanged -= Schedule_SizeChanged;
		schedule = null;
            }
        }
    }
}
