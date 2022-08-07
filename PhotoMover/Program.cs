using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PhotoMover
{
    static class Program
    {

        public static readonly string cfgPath = Path.Combine(Application.ExecutablePath + ".ini");
        public static Config AppConfig;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppConfig = Config.InitConfig(cfgPath);
            
            var type = typeof(IDateExtractor);
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract).ToList().ForEach( (t) =>
                {
                    var x = (IDateExtractor)Activator.CreateInstance(t);
                    x.Register();
                });
            Application.Run(new MainForm());
        }
    }

    
}
