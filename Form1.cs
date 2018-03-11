
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Controls;
using AForge.Video;
using AForge.Video.VFW;
using AForge.Video.DirectShow;

namespace VideoFrame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void baslat_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                FileVideoSource videoSource = new FileVideoSource(openfd.FileName);
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                videoSource.Start();
                int a = videoSource.FramesReceived;
                label1.Text = "Frames:" + a;
                //videoSource.SignalToStop();
            }
        }
        private void video_NewFrame(object sender,NewFrameEventArgs eventArgs)
        {

            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            this.Invoke((MethodInvoker)delegate
            {
                ekran.Image = bitmap;
                ekran.Refresh();

            });
        }
    }
}
