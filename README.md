# Reactive Extensions in Xamarin.Forms

An illustration demonstrating the use of Reactive Extensions in Xamarin.Forms. 

(For expedience, SmallestMvvm is used to inject the ViewModel into the page, however any alternate method could be used.)

In this illustration, an image of a clock second-hand is rotated (360 degrees / 60 seconds) every second, with the Rotation property of the Image in Xaml, bound to a property in the ViewModel. The property in the ViewModel is updated every second, using Rx.

Install the following from Nuget:

Rx-Core
Rx-Interfaces
Rx-Linq

The binding in the Xaml is as follows:

```
  <Grid>
    <Grid.RowDefinitions>
      <RowDefinition Height="Auto" />
      <RowDefinition Height="*" />      
    </Grid.RowDefinitions>
  <StackLayout Grid.Row="0" VerticalOptions="StartAndExpand" Orientation="Vertical">
    <Label Text="Reactive Extensions" HorizontalOptions="Center" FontAttributes="Bold" />
    <Label Text="Proof of Concept" HorizontalOptions="Center" FontAttributes="Bold" />
  </StackLayout>
  <Image Grid.Row="1" 
    Source="{Binding SecondHand}" 
    Rotation="{Binding Rotation}" 
    HeightRequest="200" 
    WidthRequest="200" 
    HorizontalOptions="Center" 
    VerticalOptions="Center" 
    />
  </Grid>
```

The View Model is as follows:

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

        public MainPageViewModel()
        {
            this.SecondHand = ImageSource.FromResource("ReactiveExtentionsPOC.Images.clock_second_hand.jpg");

            var oneNumberPerSecond = Observable.Interval(TimeSpan.FromSeconds(1));

            oneNumberPerSecond.Subscribe(num =>
            {
                this.Rotation = (Convert.ToInt32(num) * (360/60));
            });
        }
