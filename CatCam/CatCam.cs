using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Expression.Encoder.Devices;
using Microsoft.Expression.Encoder.Live;
using Microsoft.Expression.Encoder.ScreenCapture;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;

namespace CatCam
{
    public partial class CatCam : Form
    {
        private LiveJob _job;
        private LiveDeviceSource _deviceSource;
        

        public CatCam()
        {
            InitializeComponent();
            Console.Write("here");
            EncoderDevice video = EncoderDevices.FindDevices(EncoderDeviceType.Video)[1];
            EncoderDevice audio = EncoderDevices.FindDevices(EncoderDeviceType.Audio).First();
            StopJob();

            if (video == null || audio == null)
            {
                return;
            }

            // Starts new job for preview window
            _job = new LiveJob();

            // Checks for a/v devices
            if (video != null && audio != null)
            {
                // Create a new device source. We use the first audio and video devices on the system
                _deviceSource = _job.AddDeviceSource(video, audio);
                _deviceSource.PickBestVideoFormat(new Size(640, 480), 15);

                // Get the properties of the device video
                SourceProperties sp = _deviceSource.SourcePropertiesSnapshot();

                // Resize the preview panel to match the video device resolution set
                previewPanel.Size = new Size(sp.Size.Width, sp.Size.Height);

                // Setup the output video resolution file as the preview
                _job.OutputFormat.VideoProfile.Size = new Size(sp.Size.Width, sp.Size.Height);

               
                // Sets preview window to winform panel hosted by xaml window
                _deviceSource.PreviewWindow = new PreviewWindow(new HandleRef(previewPanel, previewPanel.Handle));

                // Make this source the active one
                _job.ActivateSource(_deviceSource);

                snapButton.Enabled = true;
            }
            else
            {
                // Gives error message as no audio and/or video devices found
                MessageBox.Show("No Video/Audio capture devices have been found.", "Warning");
            }
        }

        private void snapButton_Click(object sender, EventArgs e)        
        {
            takePhoto();
        }

        // Handle the KeyDown event to determine the type of character entered into the control. 
        private void CatCam_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
           
            // Determine whether the keystroke is a number from the top of the keyboard. 
            if (e.KeyCode < Keys.Space)
            {
                takePhoto();
            }

        }

        private void takePhoto()
        {

            // Create a Bitmap of the same dimension of panelVideoPreview (Width x Height)
            using (Bitmap bitmap = new Bitmap(previewPanel.Width, previewPanel.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    // Get the paramters to call g.CopyFromScreen and get the image
                    Rectangle rectanglePanelVideoPreview = previewPanel.Bounds;
                    Point sourcePoints = previewPanel.PointToScreen(new Point(previewPanel.ClientRectangle.X, previewPanel.ClientRectangle.Y));
                    g.CopyFromScreen(sourcePoints, Point.Empty, rectanglePanelVideoPreview.Size);
                }

                string strGrabFileName = String.Format("C:\\Users\\Kate\\Dropbox\\Harry\\Snapshot_{0:yyyyMMdd_hhmmss}.jpg", DateTime.Now);
                bitmap.Save(strGrabFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                
            } 

        }
        
        
        void StopJob()
        {
            // Has the Job already been created ?
            if (_job != null)
            {

                _job.StopEncoding();

                // Remove the Device Source and destroy the job
                _job.RemoveDeviceSource(_deviceSource);

                // Destroy the device source
                _deviceSource.PreviewWindow = null;                
                _deviceSource = null;                
            }
        }

        private void CatCam_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopJob();
        }

    }
}
