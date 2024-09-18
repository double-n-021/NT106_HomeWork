using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class Form1 : Form
    {
        private List<string> imagePaths = new List<string>();
        private int currentImageIndex = 0;
        private FlowLayoutPanel thumbnailPanel;

        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
            InitializeThumbnailPanel();
        }

        private void InitializeThumbnailPanel()
        {
            thumbnailPanel = new FlowLayoutPanel();
            thumbnailPanel.Dock = DockStyle.Bottom;
            thumbnailPanel.Height = 100;
            thumbnailPanel.AutoScroll = true;
            this.Controls.Add(thumbnailPanel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePaths.AddRange(openFileDialog1.FileNames);
                LoadThumbnails();
                DisplayImage(0);
            }
        }

        private void LoadThumbnails()
        {
            thumbnailPanel.Controls.Clear();
            foreach (var path in imagePaths)
            {
                PictureBox thumbnail = new PictureBox();
                thumbnail.Image = Image.FromFile(path);
                thumbnail.SizeMode = PictureBoxSizeMode.Zoom;
                thumbnail.Width = 80;
                thumbnail.Height = 80;
                thumbnail.Click += Thumbnail_Click;
                thumbnailPanel.Controls.Add(thumbnail);
            }
        }

        private void Thumbnail_Click(object sender, EventArgs e)
        {
            PictureBox clickedThumbnail = sender as PictureBox;
            int index = thumbnailPanel.Controls.IndexOf(clickedThumbnail);
            DisplayImage(index);
        }

        private void DisplayImage(int index)
        {
            if (index >= 0 && index < imagePaths.Count)
            {
                pictureBox1.Image = Image.FromFile(imagePaths[index]);
                currentImageIndex = index;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            imagePaths.Clear();
            thumbnailPanel.Controls.Clear();
            currentImageIndex = 0;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Left:
                    NavigateImage(-1);
                    break;
                case Keys.Right:
                    NavigateImage(1);
                    break;
            }
        }

        private void NavigateImage(int direction)
        {
            int newIndex = (currentImageIndex + direction + imagePaths.Count) % imagePaths.Count;
            DisplayImage(newIndex);
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            PictureBoxSizeMode newSizeMode = checkBox1.Checked ? PictureBoxSizeMode.StretchImage : PictureBoxSizeMode.Zoom;
            pictureBox1.SizeMode = newSizeMode;
            foreach (Control control in thumbnailPanel.Controls)
            {
                if (control is PictureBox)
                {
                    ((PictureBox)control).SizeMode = newSizeMode;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
