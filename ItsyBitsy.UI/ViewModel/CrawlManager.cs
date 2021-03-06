﻿using ItsyBitsy.Domain;
using System;
using System.Threading.Tasks;

namespace ItsyBitsy.UI
{
    public sealed class CrawlManager
    {
        private readonly Crawler _crawler;

        public CrawlManager()
        {
            _crawler = new Crawler(CrawlProgress.Instance, Settings.Instance);
        }

        public async Task Start(Website website)
        {
            var sessionId = await Repository.CreateNewSession();
            _crawler.Start(website, sessionId);
        }

        public async Task HardStop()
        {
            await _crawler.HardStop();
        }

        public void Pause()
        {
            _crawler.Pause();
        }

        public void Resume()
        {
            _crawler.Resume();
        }

        public class ProgressEventArgs : EventArgs
        {
            public ProgressEventArgs(CrawlProgress progress)
            {
                Progress = progress;
            }

            public CrawlProgress Progress { get; set; }
        }
    }
}
