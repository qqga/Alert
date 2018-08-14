using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace AlertWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var args = Environment.GetCommandLineArgs().Skip(1);

            var parceRes = CommandLine.Parser.Default.ParseArguments<CmdArgs>(args)
                .WithParsed(opts => AlertUtil.Alert(opts, () => ShowMessage(opts.AlertMessage)));
            
            parceRes.WithNotParsed(errs => {

                HelpText autoBuild = CommandLine.Text.HelpText.AutoBuild(parceRes);
                AlertTextBlock.FontSize = 26;
                ShowMessage(autoBuild.ToString());

            });
            //if(parceRes is NotParsed<CmdArgs>)
            
        }


        void ShowMessage(string message)
        {
            this.WindowState = WindowState.Maximized;
            AlertTextBlock.MouseDown += delegate { Shutdown(); };
            AlertTextBlock.Text = message;
        }

        void Shutdown() => Application.Current.Shutdown();

    }
}
