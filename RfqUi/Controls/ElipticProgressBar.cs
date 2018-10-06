using System;
using System.CodeDom;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RfqUi.Controls
{
    public class ElipticProgressBar : Control
    {
        static ElipticProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ElipticProgressBar), new FrameworkPropertyMetadata(typeof(ElipticProgressBar)));
        }

        public static readonly DependencyProperty DirectionProperty = DependencyProperty.Register(
            "Direction", typeof(SweepDirection), typeof(ElipticProgressBar),
        new UIPropertyMetadata(SweepDirection.Counterclockwise));

        public SweepDirection Direction
        {
            get { return (SweepDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue", typeof(int), typeof(ElipticProgressBar), new PropertyMetadata(default(int)));

        public int MaxValue
        {
            get { return (int)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public static readonly DependencyProperty ArcAngleProperty = DependencyProperty.Register(
             "ArcAngle", typeof(double), typeof(ElipticProgressBar), new PropertyMetadata(default(double)));

        public double ArcAngle
        {
            get { return (int)GetValue(ArcAngleProperty); }
            set { SetValue(ArcAngleProperty, value); }
        }

        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(
            "Progress", typeof(int), typeof(ElipticProgressBar), new FrameworkPropertyMetadata(
                new CoerceValueCallback(CoerceCurrentReading),
                new PropertyChangedCallback(ProgressChanged)
            ) { DefaultValue = 0 });

        private static object CoerceCurrentReading(DependencyObject d, object basevalue)
        {
            var newValue = (int)basevalue;
            if (newValue < 0) return 0;

            var progressBar = (ElipticProgressBar)d;
            return newValue > progressBar.MaxValue ? progressBar.MaxValue : newValue;
        }

        public int Progress
        {
            get { return (int)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        private static void ProgressChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var control = (ElipticProgressBar)dependencyObject;

            var value = (int)dependencyPropertyChangedEventArgs.NewValue;
            var angle = 360 * value / control.MaxValue;

            var arcAngle = angle;
            if (control.Direction == SweepDirection.Clockwise)
            {
                arcAngle = 360 - angle;

                //arcAngle = value > control.MaxValue ? 0 : arcAngle;
                //arcAngle = arcAngle == 0 ? 1 : arcAngle;
            }

            if (control.Direction == SweepDirection.Counterclockwise)
            {
                //arcAngle = value > control.MaxValue ? 0 : arcAngle;
            }

            control.ArcAngle = arcAngle;// == 360 ? arcAngle-0.01 : arcAngle;
        }

        public static readonly DependencyProperty BarTicknessProperty = DependencyProperty.Register(
            "BarTickness", typeof(double), typeof(ElipticProgressBar), new FrameworkPropertyMetadata(default(double)));

        public double BarTickness
        {
            get { return (double)GetValue(BarTicknessProperty); }
            set { SetValue(BarTicknessProperty, value); }
        }

        public static readonly DependencyProperty BarColorProperty = DependencyProperty.Register(
            "BarColor", typeof(Brush), typeof(ElipticProgressBar), new FrameworkPropertyMetadata(default(Brush)));

        public Brush BarColor
        {
            get { return (Brush)GetValue(BarColorProperty); }
            set { SetValue(BarColorProperty, value); }
        }
    }
}
