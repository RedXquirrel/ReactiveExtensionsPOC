# Reactive Extensions in Xamarin.Forms
Binding in the Xaml to a property in the ViewModel that is updated by a Reactive Extension Observable causes a second hand jpg to rotate, second by second.

Install the following from Nuget:

Rx-Core
Rx-Interfaces
Rx-Linq

In the Xaml:

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

In the View Model:

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
