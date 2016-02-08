using Com.Xamtastic.Patterns.SmallestMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ReactiveExtentionsPOC.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private int _rotation;
        public int Rotation
        {
            get
            {
                return _rotation;
            }
            set
            {
                _rotation = value;
                RaisePropertyChanged("Rotation");
            }
        }

        private ImageSource _secondhand;
        public ImageSource SecondHand
        {
            get
            {
                return _secondhand;
            }
            set
            {
                _secondhand = value;
                RaisePropertyChanged("SecondHand");
            }
        }

        public MainPageViewModel()
        {
            this.SecondHand = ImageSource.FromResource("ReactiveExtentionsPOC.Images.clock_second_hand.jpg");

            var oneNumberPerSecond = Observable.Interval(TimeSpan.FromSeconds(1));

            oneNumberPerSecond.Subscribe(num =>
            {
                this.Rotation = (Convert.ToInt32(num) * (360/60));
            });
        }
    }
}
