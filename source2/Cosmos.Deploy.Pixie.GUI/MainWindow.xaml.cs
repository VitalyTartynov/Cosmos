﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cosmos.Deploy.Pixie.GUI {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e) {
      string xBootFile = @"C:\Users\Atmoic\AppData\Roaming\Cosmos User Kit\Build\PXE\pxelinux.0";
      var xServerIP = new byte[] { 192, 168, 42, 1 };

      var xBOOTP = new DHCP(xServerIP, xBootFile);
      xBOOTP.Execute();

      var xTFTP = new TrivialFTP(xServerIP, System.IO.Path.GetDirectoryName(xBootFile));
      xTFTP.Execute();
    }
  }
}