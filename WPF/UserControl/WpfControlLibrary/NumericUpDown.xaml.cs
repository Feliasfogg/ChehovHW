using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfControlLibrary {
   /// <summary>
   /// Interaction logic for NumericUpDown.xaml
   /// </summary>
   public partial class NumericUpDown : UserControl {
      private static DependencyProperty MaximumProperty = DependencyProperty.Register(
         "Maximum",
         typeof(decimal),
         typeof(NumericUpDown),
         new PropertyMetadata(Convert.ToDecimal(1000000), new PropertyChangedCallback(MaximumValueChanged)));

      private static DependencyProperty MinimumProperty = DependencyProperty.Register(
         "Minimum",
         typeof(decimal),
         typeof(NumericUpDown),
         new PropertyMetadata(Convert.ToDecimal(-1000000), new PropertyChangedCallback(MinimumValueChanged)));

      private static DependencyProperty ValueProperty = DependencyProperty.Register(
         "Value",
         typeof(decimal),
         typeof(NumericUpDown),
         new PropertyMetadata(Convert.ToDecimal(0), new PropertyChangedCallback(OnValueChanged), new CoerceValueCallback(CoerceValue)));


      private static DependencyProperty IntervalProperty = DependencyProperty.Register(
         "Interval",
         typeof(decimal),
         typeof(NumericUpDown),
         new PropertyMetadata(Convert.ToDecimal(1), new PropertyChangedCallback(OnIntervalChanged), new CoerceValueCallback(CoerceInterval)));

      private static DependencyProperty DecimalPlacesProperty = DependencyProperty.Register(
         "DecimalPlaces",
         typeof(int),
         typeof(NumericUpDown),
         new PropertyMetadata(2, new PropertyChangedCallback(OnDecimalPlacesChanged), new CoerceValueCallback(CoerceDecimalPlaces)));

      private static readonly RoutedEvent ValueChangedEvent =
         EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(NumericUpDown));

      private static readonly RoutedEvent IncreaseClickedEvent =
         EventManager.RegisterRoutedEvent("IncreaseClicked", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(NumericUpDown));

      private static readonly RoutedEvent DecreaseClickedEvent =
         EventManager.RegisterRoutedEvent("DecreaseClicked", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(NumericUpDown));

      private static RoutedCommand _IncreaseCommand;
      private static RoutedCommand _DecreaseCommand;

      public static RoutedCommand IncreaseCommand {
         get { return _IncreaseCommand; }
      }

      public static RoutedCommand DecreaseCommand {
         get { return _DecreaseCommand; }
      }

      public int DecimalPlaces {
         get { return (int)GetValue(DecimalPlacesProperty); }
         set { SetValue(DecimalPlacesProperty, value); }
      }

      public decimal Interval {
         get { return (decimal)GetValue(IntervalProperty); }
         set { SetValue(IntervalProperty, value); }
      }

      public decimal Value {
         get { return (decimal)GetValue(ValueProperty); }
         set { SetValue(ValueProperty, value); }
      }

      public decimal Maximum {
         get { return (decimal)GetValue(MaximumProperty); }
         set { SetValue(MaximumProperty, value); }
      }

      public decimal Minimum {
         get { return (decimal)GetValue(MinimumProperty); }
         set { SetValue(MinimumProperty, value); }
      }

      public event RoutedEventHandler ValueChanged {
         add { AddHandler(ValueChangedEvent, value); }
         remove { RemoveHandler(ValueChangedEvent, value); }
      }

      public event RoutedEventHandler IncreaseClicked {
         add { AddHandler(IncreaseClickedEvent, value); }
         remove { RemoveHandler(IncreaseClickedEvent, value); }
      }

      public event RoutedEventHandler DecreaseClicked {
         add { AddHandler(DecreaseClickedEvent, value); }
         remove { RemoveHandler(DecreaseClickedEvent, value); }
      }

      static NumericUpDown() {
         EventManager.RegisterClassHandler(
            typeof(NumericUpDown), Mouse.MouseDownEvent,
            new MouseButtonEventHandler(NumericUpDown.OnMouseLeftButtonDown), true);

         InitializeCommands();
      }

      public NumericUpDown() {
         InitializeComponent();
      }

      private static object CoerceValue(DependencyObject dependencyObject, object baseValue) {
         decimal value = (decimal)baseValue;
         NumericUpDown control = dependencyObject as NumericUpDown;

         if(value < control.Minimum) {
            return control.Minimum;
         }
         if(value > control.Maximum) {
            return control.Maximum;
         }

         return Math.Round(value, control.DecimalPlaces);
      }

      private static object CoerceDecimalPlaces(DependencyObject dependencyObject, object baseValue) {
         int value = (int)baseValue;
         NumericUpDown control = dependencyObject as NumericUpDown;

         if(value < 0) {
            return control.DecimalPlaces;
         }
         if(value > 10) {
            return control.DecimalPlaces;
         }

         return value;
      }

      private static object CoerceInterval(DependencyObject dependencyObject, object baseValue) {
         decimal value = (Decimal)baseValue;
         NumericUpDown control = dependencyObject as NumericUpDown;

         if(value < 0) {
            return control.Interval;
         }
         if(value > control.Maximum) {
            return control.Interval;
         }

         return value;
      }

      private static void InitializeCommands() {
         _IncreaseCommand = new RoutedCommand("IncreaseCommand", typeof(NumericUpDown));
         CommandManager.RegisterClassCommandBinding(typeof(NumericUpDown), new CommandBinding(_IncreaseCommand, OnIncreaseCommand));
         CommandManager.RegisterClassInputBinding(typeof(NumericUpDown), new InputBinding(_IncreaseCommand, new KeyGesture(Key.Up)));

         _DecreaseCommand = new RoutedCommand("DecreaseCommand", typeof(NumericUpDown));
         CommandManager.RegisterClassCommandBinding(typeof(NumericUpDown), new CommandBinding(_DecreaseCommand, OnDecreaseCommand));
         CommandManager.RegisterClassInputBinding(typeof(NumericUpDown), new InputBinding(_DecreaseCommand, new KeyGesture(Key.Down)));
      }

      private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
         NumericUpDown control = sender as NumericUpDown;
         decimal dValue = control.Value;
         if(e.Property == ValueProperty) {
            dValue = (decimal)e.NewValue;

            control.Value = dValue;
         }
         control.textBox.Text = control.Value.ToString();
      }

      private static void OnDecimalPlacesChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
         NumericUpDown objNumericUpDown = sender as NumericUpDown;
         int dDecimalPlaces = objNumericUpDown.DecimalPlaces;
         if(e.Property == IntervalProperty) {
            dDecimalPlaces = (int)e.NewValue;
         }
         objNumericUpDown.DecimalPlaces = dDecimalPlaces;
      }

      private static void OnIntervalChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
         NumericUpDown objNumericUpDown = sender as NumericUpDown;
         decimal dInterval = objNumericUpDown.Interval;
         if(e.Property == IntervalProperty) {
            dInterval = (decimal)e.NewValue;
         }
         objNumericUpDown.Interval = dInterval;
      }

      private static void MaximumValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
         NumericUpDown objNumericUpDown = sender as NumericUpDown;
         decimal dValue = objNumericUpDown.Maximum;
         if(e.Property == ValueProperty) {
            dValue = (decimal)e.NewValue;

            objNumericUpDown.Maximum = dValue;
         }
      }

      private static void MinimumValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
         NumericUpDown objNumericUpDown = sender as NumericUpDown;
         decimal dValue = objNumericUpDown.Minimum;
         if(e.Property == ValueProperty) {
            dValue = (decimal)e.NewValue;

            objNumericUpDown.Minimum = dValue;
         }
      }

      private static void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
         NumericUpDown control = sender as NumericUpDown;

         if(control.buttonUp.IsMouseCaptured) {
            OnIncreaseCommand(sender, null);
         }
         if(control.buttonDown.IsMouseCaptured) {
            OnDecreaseCommand(sender, null);
         }
         control.textBox.Text = control.Value.ToString();
      }

      private static void OnIncreaseCommand(object sender, ExecutedRoutedEventArgs e) {
         NumericUpDown control = sender as NumericUpDown;
         if(control != null) {
            control.Value += control.Interval;
         }
      }

      private static void OnDecreaseCommand(object sender, ExecutedRoutedEventArgs e) {
         NumericUpDown control = sender as NumericUpDown;
         if(control != null) {
            control.Value -= control.Interval;
         }
      }

      private void textBox_TextChanged(object sender, TextChangedEventArgs e) {
         var textBox = (TextBox)sender;
         decimal dTemp;
         if(Decimal.TryParse(textBox.Text, out dTemp)) {
            this.Value = dTemp;
         }
      }
   }
}