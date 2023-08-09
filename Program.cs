using System;
using NAudio.Wave;
using System.Diagnostics.Metrics;
using System.Timers;
using System.Reflection;

namespace AudioPlayerApp
{
    class Program
    {

        public AudioFileReader audioFile;
        public WaveOutEvent outputDevice;

        public int counter = 0;
        static void Main(string[] args)
        {
            string firstAudioUrl = @"C:\temp\timeraudio\music\07 - Hexagon.mp3";
            string secondAudioUrl = @"C:\temp\timeraudio\music\08 - Blur.mp3";
            Program p = new Program();
            p.ActionAndNonAction(firstAudioUrl, 600, secondAudioUrl, 1800);
        }
        private void ActionAndNonAction(string firstAudioUrl, int firstAudioDurationInSeconds, string secondAudioUrl, int secondAudioDurationInSeconds)
        {
            string daBeep = @"C:\temp\timeraudio\effects\beep-05.mp3";
            while (true)
            {
                //PlayOnLoopFor(firstAudioUrl, firstAudioDurationInSeconds);
                PlayOnLoopFor(daBeep, 5);
                PlayOnLoopFor(secondAudioUrl, secondAudioDurationInSeconds);
            }
        }

        private void PlayOnLoopFor(string firstAudioUrl, int timeinseconds)
        {
            audioFile = new AudioFileReader(firstAudioUrl);
            outputDevice = new WaveOutEvent();
            int counter = 0;
            outputDevice.Init(audioFile);
            outputDevice.Play();
            while (counter < timeinseconds)
            {
                Thread.Sleep(1000);
                if (outputDevice.PlaybackState == PlaybackState.Stopped)
                {
                    outputDevice.Play();
                }

                if (outputDevice.PlaybackState != PlaybackState.Paused)
                {
                    counter++;
                }
            }
        }
    }
}

