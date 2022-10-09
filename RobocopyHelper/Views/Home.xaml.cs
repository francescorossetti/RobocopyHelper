using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using WindowsFolderPicker = Windows.Storage.Pickers.FolderPicker;

namespace RobocopyHelper.Views
{
    public sealed partial class Home : Page
    {
        string srcPath;
        string dstPath;

        public Home()
        {
            this.InitializeComponent();

            this.srcPath = "";
            this.dstPath = "";
        }

        private async void SRC_Dir_Click(object sender, RoutedEventArgs e)
        {
            var path = await PickPathAsync();
            this.srcPath = path;
            srcPathTextBox.Text = path;
        }

        private async void DST_Dir_Click(object sender, RoutedEventArgs e)
        {
            var path = await PickPathAsync();
            this.dstPath = path;
            dstPathTextBox.Text = path;
        }

        private async Task<string> PickPathAsync()
        {
            var folderPicker = new WindowsFolderPicker();
            folderPicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;

            // Get the current window's HWND by passing in the Window object
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.RuntimeWindow);

            // Associate the HWND with the file picker
            WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hwnd);

            var path = (await folderPicker.PickSingleFolderAsync());

            if (path != null)
            {
                return path.Path;
            }

            return "";
        }
    }
}
