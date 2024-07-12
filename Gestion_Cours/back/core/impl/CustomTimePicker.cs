using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Wpf.Toolkit;

namespace Gestion_Cours.back.core.impl
{

    //public class CustomTimePicker : TimePicker
    //{
    //    public static readonly DependencyProperty HeureDebutProperty = DependencyProperty.Register("HeureDebut", typeof(TimeSpan), typeof(CustomTimePicker));

    //    public TimeSpan HeureDebut
    //    {
    //        get { return (TimeSpan)GetValue(HeureDebutProperty); }
    //        set { SetValue(HeureDebutProperty, value); }
    //    }

    //    public static readonly DependencyProperty HeureFinProperty = DependencyProperty.Register("HeureFin", typeof(TimeSpan), typeof(CustomTimePicker));

    //    public TimeSpan HeureFin
    //    {
    //        get { return (TimeSpan)GetValue(HeureFinProperty); }
    //        set { SetValue(HeureFinProperty, value); }
    //    }

    //    protected override void OnSelectedTimeChanged()
    //    {
    //        base.OnValueChanged();

    //        if (SelectedTime.HasValue)
    //        {
    //            if (SelectedTime < HeureDebut || SelectedTime > HeureFin)
    //            {
    //                SelectedTime = null;
    //            }
    //        }
    //    }
    public class CustomTimePicker : TimePicker
    {
        public DateTime HeureDebut { get; set; }
        public DateTime HeureFin { get; set; }

        protected override void OnValueChanged(DateTime? oldValue, DateTime? newValue)
        {
            base.OnValueChanged(oldValue, newValue);

            if (newValue.HasValue)
            {
                TimeSpan selectedTime = newValue.Value.TimeOfDay < HeureDebut.TimeOfDay || newValue.Value.TimeOfDay > HeureFin.TimeOfDay
                    ? (oldValue.HasValue ? oldValue.Value.TimeOfDay : HeureDebut.TimeOfDay)
                    : newValue.Value.TimeOfDay;

                Value = DateTime.Today.Add(selectedTime);
            }
        }
    }





}
