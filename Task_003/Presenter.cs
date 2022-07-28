using MailChimp.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Task_003
{
    internal class Presenter
    {
        public Model? model = null;
        public MainWindow? mainWindow = null;
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        TimeSpan diference;
        DateTime startTimer;
        TimeSpan savedDifference;

        public Presenter(MainWindow mainWindow)
        {
            model = new Model();
            this.mainWindow = mainWindow;
            this.mainWindow.Start += new EventHandler(mainWindow_start);
            this.mainWindow.Stop += new EventHandler(mainWindow_stop);
            this.mainWindow.Reset += new EventHandler(mainWindow_reset);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
        }

        private void mainWindow_start(object sender, EventArgs e)
        {
            startTimer = DateTime.Now;
            dispatcherTimer.Start();
        }

        private void mainWindow_stop(object sender, EventArgs e)
        {
            dispatcherTimer.Stop();
            savedDifference = diference;
        }

        private void mainWindow_reset(object sender, EventArgs e)
        {
            dispatcherTimer.Stop();
            savedDifference = new TimeSpan(0, 0, 0);
            mainWindow.TimerTextBox.Text = savedDifference.ToString(@"mm\:ss");
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            diference = DateTime.Now - startTimer + savedDifference;
            mainWindow.TimerTextBox.Text = diference.ToString(@"mm\:ss");
        }
    }
}
