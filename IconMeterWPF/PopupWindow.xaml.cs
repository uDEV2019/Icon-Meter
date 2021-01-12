﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IconMeterWPF
{
	/// <summary>
	/// Interaction logic for PopupWindow.xaml
	/// </summary>
	public partial class PopupWindow : UserControl
	{
		public PopupWindow()
		{
			InitializeComponent();
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			var vm = this.DataContext as MainViewModel;
			vm?.PopupMeter?.Resume();
		}

		private void UserControl_Unloaded(object sender, RoutedEventArgs e)
		{
			var vm = this.DataContext as MainViewModel;
			vm?.PopupMeter?.Pause();
		}

		private void Image_MouseUp(object sender, MouseButtonEventArgs e)
		{
			var img = sender as Image;
			ImagePressed(img);
		}

		private void Image_TouchUp(object sender, TouchEventArgs e)
		{
			var img = sender as Image;
			ImagePressed(img);
		}

		private void ImagePressed(Image sender)
		{
			if (sender == this.ImageClose)
			{
				// hide popup window
				var p = this.Parent as Popup;
				p.IsOpen = false;
			}

			if (sender == this.ImageConfig)
			{
				// pause update readings
				var vm = this.DataContext as MainViewModel;
				vm?.PauseUpdate();

				// hide popup window
				var p = this.Parent as Popup;
				p.IsOpen = false;

				// show setting window
				vm?.MainWindow.Show();
			}

			if (sender == this.ImageTask)
			{
				// start task manager
				System.Diagnostics.Process.Start("taskmgr");
			}

			if (sender == this.ImageControl)
			{
				// start control panel
				System.Diagnostics.Process.Start("control");
			}

			if (sender == this.ImageRefresh)
			{
				var vm = this.DataContext as MainViewModel;
				vm?.PopupMeter.UpdateIPs();
			}
		}
	}
}
