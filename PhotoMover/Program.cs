using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PhotoMover
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //FileProcessorFactory.addExt(DefaultInfoReader.EXT, DefaultInfoReader.Instance);
            //FileProcessorFactory.addExt(JpgInfoReader.EXT, JpgInfoReader.Instance);
            IncludeSub = true;
            DeleteEmpty = true;
            ShowList = true;
            ExistTarget = 3;
            CopyOrMove = 2;
            readFromIni();
            var type = typeof(DateProviderBase);
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract).ToList().ForEach( (t) =>
                {
                    var x = (DateProviderBase)Activator.CreateInstance(t);
                    x.Register();
                });

            Application.Run(new Form1());
        }
        public static readonly string cfgPath = Path.Combine(Application.StartupPath, "PhotoMover.ini");
        public static string SrcList, DestList,StructList, TimeFieldName;
        public static bool IncludeSub, DeleteEmpty, ShowList;
        public static int ExistTarget, CopyOrMove;
        static void readFromIni()
        {
            if (File.Exists(cfgPath))
            {
                IniFile ini = new IniFile(cfgPath);
                bool parseResult;
                SrcList = ini.IniReadValue("Config", "Src");
                parseResult = bool.TryParse(ini.IniReadValue("Config", "IncludeSub"), out IncludeSub);
                parseResult = bool.TryParse(ini.IniReadValue("Config", "DeleteEmpty"), out DeleteEmpty);
                DestList = ini.IniReadValue("Config", "Dest");
                StructList = ini.IniReadValue("Config", "Struct");
                parseResult = int.TryParse(ini.IniReadValue("Config", "ExistTarget"), out ExistTarget);
                parseResult = int.TryParse(ini.IniReadValue("Config", "CopyOrMove"), out CopyOrMove);
                TimeFieldName = ini.IniReadValue("Config", "TimeField");
                parseResult = bool.TryParse(ini.IniReadValue("Config", "ShowList"), out ShowList);
            }
            if (string.IsNullOrEmpty(TimeFieldName)) TimeFieldName = "DTOrig";
        }
    }

    
}
