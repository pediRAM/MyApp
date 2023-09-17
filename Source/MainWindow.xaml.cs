using System;
using System.Text;
using System.Windows;
using System.Linq;


namespace MyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            var args = Environment.GetCommandLineArgs();
            if (args != null && args.Length > 1) 
            { 
                if (System.IO.File.Exists(args[1]))
                {
                    textbox.Text = System.IO.File.ReadAllText(args[1]);  
                }
            }
            else
            {
                var envVarTime = Environment.GetEnvironmentVariable("time");
                var envVars = Environment.GetEnvironmentVariables();
                var envVarsMachine = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine);
                var envVarsUser = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User);

                var sb = new StringBuilder();

                sb.AppendLine("\n\n***** Environment Variables: *****");
                foreach (var k in envVars.Keys)
                    sb.AppendLine($"{k} = \"{envVars[k]}\"");

                sb.AppendLine();

                sb.AppendLine("\n\n***** Environment Variables of Machine: *****");
                foreach (var k in envVarsMachine.Keys)
                    sb.AppendLine($"{k} = \"{envVarsMachine[k]}\"");

                sb.AppendLine();

                sb.AppendLine("\n\n***** Environment Variables of User: *****");
                foreach (var k in envVarsUser.Keys)
                    sb.AppendLine($"{k} = \"{envVarsUser[k]}\"");

                sb.AppendLine();

                textbox.Text = sb.ToString();
            }
        }
    }
}
