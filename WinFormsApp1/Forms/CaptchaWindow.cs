using System;
using System.Media;

namespace WinFormsApp1.Forms
{
    public partial class CaptchaWindow : Form
    {
        private int soundCount;
        public CaptchaWindow()
        {
            InitializeComponent();
            soundCount = 0;
        }

        private void CaptchaWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private Task playSoundAsync(byte[][] sounds)
        {
            return Task.Run(() => {
                foreach (var sound in sounds) {
                    using (var stream = new MemoryStream(sound))
                    {
                        new SoundPlayer(stream).PlaySync();
                    }
                }
            });
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            byte[][] sounds = new byte[3][];

            switch (soundCount)
            {
                case 0:
                    sounds[0] = Properties.Resources.noise2;
                    sounds[1] = Properties.Resources.drum1;
                    sounds[2] = Properties.Resources.phone;
                    soundCount++;
                    break;
                case 1:
                    sounds[0] = Properties.Resources.noise;
                    sounds[1] = Properties.Resources.ting;
                    sounds[2] = Properties.Resources.drum2;
                    soundCount++;
                    break;
                case 2:
                    sounds[0] = Properties.Resources.drum3;
                    sounds[1] = Properties.Resources.wuuuuuuuuu;
                    sounds[2] = Properties.Resources.random;
                    soundCount++;
                    break;
                default:
                    break;

            };

            await playSoundAsync(sounds);
            button1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
