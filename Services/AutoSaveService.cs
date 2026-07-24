using System;
using System.Timers;
using NBoard.Models;

namespace NBoard.Services
{
    public class AutoSaveService
    {
        private Timer _timer;
        private Document _document;
        private int _intervalSeconds = 30;

        public AutoSaveService(Document document, int intervalSeconds = 30)
        {
            _document = document;
            _intervalSeconds = intervalSeconds;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            _timer = new Timer(_intervalSeconds * 1000);
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (_document != null)
                {
                    DocumentManager.SaveDocument(_document);
                    Console.WriteLine($"Auto-save completed at {DateTime.Now}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Auto-save error: {ex.Message}");
            }
        }

        public void UpdateDocument(Document document)
        {
            _document = document;
        }

        public void Stop()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
            }
        }

        public void Start()
        {
            if (_timer != null)
            {
                _timer.Start();
            }
        }
    }
}