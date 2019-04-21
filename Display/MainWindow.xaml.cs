using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Flock;
using Point = Flock.Point;

namespace Display
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		private System.Timers.Timer timer;
		private BirdGroup group;
		public MainWindow()
		{
			InitializeComponent();

			timer = new Timer(150);
			timer.Elapsed += Timer_Elapsed;


		}

		private void Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			group.Tick();

			Dispatcher.Invoke(() =>
			{
				MyCanvas.Children.Clear();
				foreach (var bird in @group.Birds)
				{
					AddText(bird.Location, bird.BirdNum.ToString(), Color.FromRgb(255,0,0));
				}
				AddPoint(@group.GroupCenter);
			});
		}


		private void AddPoint(Point point)
		{
			var dot = new Ellipse
			{
				Width = 5,
				Height = 5,
				Stroke = Brushes.Red,
				Fill = Brushes.Red
			};
			MyCanvas.Children.Add(dot);
			Canvas.SetTop(dot, point.Y);
			Canvas.SetLeft(dot, point.X);
		}

		private void AddText(Point point, string text, Color color)
		{
			TextBlock textBlock = new TextBlock {Text = text, Foreground = new SolidColorBrush(color)};
			MyCanvas.Children.Add(textBlock);
			Canvas.SetLeft(textBlock, point.X);
			Canvas.SetTop(textBlock, point.Y);
		}

		private void BtnClear_Click(object sender, RoutedEventArgs e)
		{
			Dispatcher.BeginInvoke(new Action(() =>
			{
				MyCanvas.Children.Clear();
			}));
		}

		private void BtnBegin_Click(object sender, RoutedEventArgs e)
		{
			timer.Start();
			group = new BirdGroup(10, (int)MyCanvas.Width, (int)MyCanvas.Height);
		}

		private void BtnEnd_Click(object sender, RoutedEventArgs e)
		{
			timer.Stop();
		}
	}
}
