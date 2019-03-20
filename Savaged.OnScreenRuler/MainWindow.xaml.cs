﻿using Savaged.OnScreenRulerLib.Models;
using Savaged.OnScreenRulerLib.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Savaged.OnSreenRuler
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void OnSourceInitialized(object sender, EventArgs e)
        {
            if (DataContext is MainViewModel mainViewModel)
            {
                mainViewModel.ColourChanged += OnColourChanged;
                mainViewModel.Close = new Action(Close);
                mainViewModel.Load();
            }
        }

        private void OnColourChanged(object sender, ColourChangedEventArgs e)
        {
            var converter = new BrushConverter();
            var brush = (SolidColorBrush)converter.ConvertFromString(e.Colour);
            ContentGrid.Background = brush;
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            if (DataContext is MainViewModel mainViewModel)
            {
                mainViewModel.ColourChanged -= OnColourChanged;
                mainViewModel.Close = null;
            }
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}