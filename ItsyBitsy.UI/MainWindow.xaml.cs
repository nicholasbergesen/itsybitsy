﻿using ItsyBitsy.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace ItsyBitsy.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly CrawlManager _crawlManager;

        public MainWindow()
        {
            _crawlManager = new CrawlManager();
            InitializeComponent();
        }

        private async void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            if (selectedWebsite.SelectedItem is Website website)
            {
                btnStart.IsEnabled = false; //enable on crawl onComplete event
                await _crawlManager.Start(website);
            }
        }

        private async void BtnHardStop_Click(object sender, RoutedEventArgs e)
        {
            await _crawlManager.HardStop();
        }

        private async void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            await _crawlManager.Pause();
        }

        private async void BtnResume_Click(object sender, RoutedEventArgs e)
        {
            await _crawlManager.Resume();
        }

        private void BtnDrainStop_Click(object sender, RoutedEventArgs e)
        {
            _crawlManager.DrawinStop();
        }

        private async void AddWebsite_Click(object sender, RoutedEventArgs e)
        {
            var seed = websiteSeed.Text;
            try
            {
                await Repository.CreateWebsite(seed);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding website", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}