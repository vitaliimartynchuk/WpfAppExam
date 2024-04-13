using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Windows.Threading;

namespace WpfAppExam
{
    [AddINotifyPropertyChangedInterface]
    class ViewModel 
    {
        public Keyboard_simulator keyboard_simulator { get; set; }

        public string letter { get; set; }
        public int numberLetter { get; set; }

        public bool gameStop = true;

        public bool timerGame = true;

        private DispatcherTimer timer;
        public int RemainingTime {  get; set; }


        RelayCommand gamestartCommand;
        RelayCommand gamestopCommand;

        public ViewModel()
        {
            gamestartCommand = new RelayCommand((o)  => GameStart(), (o) => gameStop != false);
            gamestopCommand = new RelayCommand((o) => GameStop(), (o) => gameStop != true);

            keyboard_simulator = new Keyboard_simulator();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        public ICommand GamestartCommand => gamestartCommand;
        public ICommand GamestopCommand => gamestopCommand;

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (RemainingTime > 0)
            {
                RemainingTime--;
            }
            else
            {
                timerGame = true;
                GameStop();
                MessageBox.Show($"Simulation complete\nNumber of characters per minute: {numberLetter}\nNumber of errors: {keyboard_simulator.Fale}");

            }
        }

        private void GameStart()
        {
            keyboard_simulator.StartValue();
            gameStop = false;
            keyboard_simulator.Fale = 0;
            numberLetter = 0;

            RemainingTime = 60;
            timer.Start();
            timerGame = false;
        }

        private void GameStop()
        {
            timer.Stop();

            gameStop = true;

            if(!timerGame)
            {
                int actualTimePassed = 60 - RemainingTime;  // Час, який фактично минув
                int charsPerMinute = (numberLetter / actualTimePassed) * 60;
                MessageBox.Show($"Simulation complete\nNumber of characters per minute: {charsPerMinute}\nNumber of errors: {keyboard_simulator.Fale}");
            }
        }

        public void GameText(string letter)
        {
            if (!gameStop)
            {
                if (letter == keyboard_simulator.Now)
                {
                    keyboard_simulator.ChangeText();
                    numberLetter++;
                }
                else if (letter != "LeftShift")
                {
                    keyboard_simulator.Fale++;
                }
            }
        }
    }
}
