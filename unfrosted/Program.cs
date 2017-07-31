using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Unfrosted.Forms;
using Unfrosted.Networking;

namespace Unfrosted
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        private static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var appdataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "unfrosted");
            if (!Directory.Exists(appdataPath))
                Directory.CreateDirectory(appdataPath);

            try {
                Configuration.Instance = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(Path.Combine(Application.StartupPath, "config.json")));
            } catch {
                Configuration.Instance = new Configuration();
                File.WriteAllText(Path.Combine(Application.StartupPath, "config.json"), JsonConvert.SerializeObject(Configuration.Instance));
            }

            PoolService.Instance.StartService(Configuration.Instance.PoolPort);
            MetaService.Instance.StartService(Configuration.Instance.MetaPort);
            PortController.Instance.PrepareServers();
            
            Application.Run(new MainWindow());

            PoolService.Instance.StopService();
            MetaService.Instance.StopService();
            PortController.Instance.StopServers();
        }
    }
}
