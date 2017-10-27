using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TsinghuaPerformanceAPI;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace TsinghuaPerformance
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void HHH_Click(object sender, RoutedEventArgs e)
        {
            NavMenuPrimaryListView.ItemsSource = ShowList.GetListShow();
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            ShowList.page += 1;
            NavMenuPrimaryListView.ItemsSource = ShowList.GetListShow();
        }

        private void FrontPage_Click(object sender, RoutedEventArgs e)
        {
            if (ShowList.page > 1)
            {
                ShowList.page -= 1;
                NavMenuPrimaryListView.ItemsSource = ShowList.GetListShow();
            }
            
        }
    }
}
