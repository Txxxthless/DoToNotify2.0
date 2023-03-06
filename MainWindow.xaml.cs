using DoToNotify2._0.MVVM.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Windows;

namespace DoToNotify2._0
{
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            
            var formatter = new DataContractJsonSerializer(typeof(ObservableCollection<ObjectiveViewModel>));
            if (File.Exists("UserConfig\\config.json"))
            {
                using (FileStream jsonfs = new FileStream("UserConfig\\config.json",
                FileMode.Open))
                {
                    var cfgColletion = (ObservableCollection<ObjectiveViewModel>)formatter.ReadObject(jsonfs);
                    if (cfgColletion != null)
                    {
                        viewModel._objectives = cfgColletion;
                    }                
                }
            }
            else
            {
                File.Create("UserConfig\\config.json");
            }
                
            DataContext = viewModel;
        }

        protected override void OnClosed(EventArgs e)
        {
            using FileStream jsonfs = new FileStream("UserConfig\\config.json", 
                FileMode.Create);
            var formatter = new DataContractJsonSerializer(typeof(ObservableCollection<ObjectiveViewModel>));
            formatter.WriteObject(jsonfs, viewModel.Objectives);
            base.OnClosed(e);
        }
    }
}
