using System;
using System.Windows.Forms;
using TextEditor._BL;

namespace TextEditor
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();
            FileManager manager = new FileManager();
            MessageService messageService = new MessageService();
            
            Presenter presenter = new Presenter(form, manager, messageService);
            
            Application.Run(form);
        }
    }
}