using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using itsEVEST.Model;
using itsEVEST.ViewModels;
using System;
using System.Windows;
using System.Windows.Threading;

namespace itsEVEST
{
    public partial class MainWindow : Window
    {

        public static MainWindow Instance;

        public string matchPhase { get; set; }
        public string matchClass { get; set; }
        public string matchWeight { get; set; }
        public string matchGender { get; set; }

        DispatcherTimer _timer;
        TimeSpan _time;
        private bool _isPaused = false;
        uint timeInSeconds = 120;

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "BwB7Wdx4NHC0shxdhWuHGcHdGDKwDOHBP9WcRmj2",
            BasePath = "https://testsensor-5d32b-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };

        IFirebaseConfig config2 = new FirebaseConfig
        {
            AuthSecret = "2Yd7aCHyOJqtd6bDp1rF1sXtiqibfmApdMie195I",
            BasePath = "https://protel2-b2a79-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };

        IFirebaseConfig config3 = new FirebaseConfig
        {
            AuthSecret = "AqMABMICsOXUcKVK6g5p6ZTxLoznc4VjmD6O8vN1",
            BasePath = "https://protel-7099e-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };

        FirebaseClient client;
        FirebaseClient client2;
        FirebaseClient client3;

        private EventStreamResponse listener;
        private EventStreamResponse listener2;
        private EventStreamResponse listener3;

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            MatchInfo.Text = matchPhase + " " + matchClass + " " + matchWeight + " " + matchGender;

            /*MainWindowViewModel vm = new MainWindowViewModel();
            DataContext = vm;*/

            DataInsertViewModel vm = new DataInsertViewModel();
            DataContext = vm;

            Readings readings = new Readings();
        }

        private void startTimer()
        {
            _time = TimeSpan.FromSeconds(timeInSeconds);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                if (!_isPaused)
                {
                    tbTime.Text = string.Format("{0:mm\\:ss}", _time);
                    if (_time == TimeSpan.Zero)
                    {
                        _timer.Stop();
                        _isPaused = !_isPaused;
                        winnerScreen();
                    }
                        
                    _time = _time.Add(TimeSpan.FromSeconds(-1));
                }
            }, Application.Current.Dispatcher);

            _timer.Start();
        }

        private void controlTimer()
        {
            _isPaused = !_isPaused;

            btnPauseContent.Text = _isPaused ? "Resume" : "Pause";
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            client2 = new FireSharp.FirebaseClient(config2);
            client3 = new FireSharp.FirebaseClient(config3);

            if (client != null && client2 != null && client3 != null)
            {
                MessageBox.Show("Connected");
            }

        }

        private void winnerScreen()
        {
            var redScore = int.Parse(tbRedScore.Text);
            var blueScore = int.Parse(tbBlueScore.Text);

            if (redScore > blueScore)
            {
                MessageBox.Show("SISI MERAH MENANG");
            }
            else if (blueScore > redScore)
            {
                MessageBox.Show("SISI BIRU MENANG");
            }
            else if (redScore == blueScore)
            {
                MessageBox.Show("PERTANDINGAN SERI");
            }
        }

        private void Setup_Click(object sender, RoutedEventArgs e)
        {
            DataInsertView dataInsertView = new DataInsertView(App.Current.MainWindow);
            dataInsertView.ShowDialog();

            DataInsertView.Instance.inputRedName.Text = tbRedName.Text;
            DataInsertView.Instance.inputRedTeam.Text = tbRedTeam.Text;
            DataInsertView.Instance.inputBlueName.Text = tbBlueName.Text;
            DataInsertView.Instance.inputBlueTeam.Text = tbBlueTeam.Text;

            DataInsertView.Instance.inputClass.Text = matchClass;
            DataInsertView.Instance.inputGender.Text = matchGender;
            DataInsertView.Instance.inputWeight.Text = matchWeight;
            DataInsertView.Instance.inputPhase.Text = matchPhase;
        }

        private async void Play_Click(object sender, RoutedEventArgs e)
        {
            MatchScore matchScore = new MatchScore();
            startTimer();
            LiveCall();
            
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            controlTimer();
        }

        async void LiveCall()
        {
            var redScore = int.Parse(tbRedScore.Text);
            listener = await client.OnAsync("", added: null,
                changed: (s, args, context) =>
                {
                    var dataJson = args.Data;
                    var oldDataJson = args.OldData;
                    /*Dispatcher.Invoke(() =>
                    {
                        MessageBox.Show(dataJson);
                    });*/
                    if (!_isPaused)
                    {
                        if (oldDataJson != dataJson)
                        {
                            if (dataJson.Contains("Tangan"))
                            {
                                Dispatcher.Invoke(() =>
                                {
                                    updateTB(2);
                                });
                            }
                            else if (dataJson.Contains("Kaki"))
                            {
                                Dispatcher.Invoke(() =>
                                {
                                    updateTB(3);
                                });
                            }
                        }
                    }
                }
                );
            /*if (redScore <= 0)
            {
                calibrateTB();
            }
*/
            listener2 = await client2.OnAsync("", added: null,
                changed: (s, args, context) =>
                {
                    var dataJson = args.Data;
                    var oldDataJson = args.OldData;
                    if (!_isPaused)
                    {
                        if (oldDataJson != dataJson)
                        {
                            if (dataJson.Contains("Tangan"))
                            {
                                Dispatcher.Invoke(() =>
                                {
                                    updateTB(2);
                                });
                            }
                            else if (dataJson.Contains("Kaki"))
                            {
                                Dispatcher.Invoke(() =>
                                {
                                    updateTB(3);
                                });
                            }
                        }
                    }
                }
                );
            /*if (redScore <= 0)
            {
                calibrateTB();
            }*/
            listener3 = await client3.OnAsync("", added: null,
                changed: (s, args, context) =>
                {
                    var dataJson = args.Data;
                    var oldDataJson = args.OldData;
                    if (!_isPaused)
                    {
                        if(oldDataJson != dataJson)
                        {
                            if (dataJson.Contains("Tangan"))
                            {
                                Dispatcher.Invoke(() =>
                                {
                                    updateTB(2);
                                });
                            }
                            else if (dataJson.Contains("Kaki"))
                            {
                                Dispatcher.Invoke(() =>
                                {
                                    updateTB(3);
                                });
                            }
                        }
                        
                    }
                }
                );

            /*if (redScore <= 0)
            {
                calibrateTB();
            }*/
        }
        private void updateTB(int increment)
        {
            var redScore = int.Parse(tbRedScore.Text);
            redScore += increment;
            tbRedScore.Text = redScore.ToString();
        }
        private void calibrateTB()
        {
            var redScore = int.Parse(tbRedScore.Text);
            redScore  -= 2;
            tbRedScore.Text = redScore.ToString();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            tbRedScore.Text = "0";
            tbBlueScore.Text = "0";
            _time = TimeSpan.FromSeconds(timeInSeconds);
            controlTimer();
        }
    }
}
