﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using System.Media;

namespace ControlesDelToolkit
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        KinectSensorChooser miKinect;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
           

            miKinect = new KinectSensorChooser();
            miKinect.KinectChanged += miKinect_KinectChanged;
            sensorChooserUI.KinectSensorChooser = miKinect;
            miKinect.Start();
        }

        void miKinect_KinectChanged(object sender, KinectChangedEventArgs e)
        {
            bool error = true;

            if (e.OldSensor == null)
            {
                try
                {
                    e.OldSensor.DepthStream.Disable();
                    e.OldSensor.SkeletonStream.Disable();
                }
                catch (Exception)
                {
                    error = true;
                }
            }

            if (e.NewSensor == null)
                return;

            try
            {
                e.NewSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                e.NewSensor.SkeletonStream.Enable();

                try
                {
                    e.NewSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated;
                    e.NewSensor.DepthStream.Range = DepthRange.Near;
                    e.NewSensor.SkeletonStream.EnableTrackingInNearRange = true;
                }
                catch (InvalidOperationException)
                {
                    e.NewSensor.DepthStream.Range = DepthRange.Default;
                    e.NewSensor.SkeletonStream.EnableTrackingInNearRange = false;
                }
            }
            catch (InvalidOperationException)
            {
                error = true;
            }

            ZonaCursor.KinectSensor = e.NewSensor;
        }

        private void KinectTileButton_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void KinectCircleButton_Click_1(object sender, RoutedEventArgs e)
        {
            //suena:
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "C:/Users/Fabidiamanti/Documents/gerenciainformatica/intro.wav";
            player.Play();
        }

        private void KinectTileButton_Click(object sender, RoutedEventArgs e)
        {

        }
        //Que es informacion
        private void KinectTileButton_Click_2(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "C:/Users/Fabidiamanti/Documents/gerenciainformatica/info.wav";
            player.Play();
        }
        //Btn Gerenciadel conocimiento
        private void KinectTileButton_Click_3(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "C:/Users/Fabidiamanti/Documents/gerenciainformatica/gerenia.wav";
            player.Play();
        }

        private void KinectTileButton_Click_4(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "C:/Users/Fabidiamanti/Documents/gerenciainformatica/reto.wav";
            player.Play();
        }

        private void KinectTileButton_Click_5(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "C:/Users/Fabidiamanti/Documents/gerenciainformatica/objetivos.wav";
            player.Play();
        }
        //actividades
        private void KinectTileButton_Click_6(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "C:/Users/Fabidiamanti/Documents/gerenciainformatica/actividad.wav";
            player.Play();
        }

        private void KinectTileButton_Click_7(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "C:/Users/Fabidiamanti/Documents/gerenciainformatica/mentalidad.wav";
            player.Play();
        }

        private void KinectTileButton_Click_8(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "C:/Users/Fabidiamanti/Documents/gerenciainformatica/herramienta.wav";
            player.Play();
        }

        private void KinectTileButton_Click_9(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "C:/Users/Fabidiamanti/Documents/gerenciainformatica/exito.wav";
            player.Play();
        }

        private void KinectTileButton_Click_10(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "C:/Users/Fabidiamanti/Documents/gerenciainformatica/conclusiones.wav";
            player.Play();
        }
      

    }
}
