using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualCryptography
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap original;
        private Bitmap output1;
        private Bitmap output2;
        private List<List<Color>> patterns = new List<List<Color>>//6
        {
            new List<Color> { Color.White, Color.White, Color.Black, Color.Black }, 
            new List<Color> { Color.White, Color.Black, Color.White, Color.Black }, 
            new List<Color> { Color.White, Color.Black, Color.Black, Color.White }, 
            new List<Color> { Color.Black, Color.White, Color.White, Color.Black }, 
            new List<Color> { Color.Black, Color.White, Color.Black, Color.White }, 
            new List<Color> { Color.Black, Color.Black, Color.White, Color.White }, 
        };
        private static int[] pattern= new int[4];
        Random random = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\R2R2\Desktop",
                Title = "Wybierz Obraz",
                CheckFileExists = true,
                CheckPathExists = true,
                RestoreDirectory = true,
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                original = new Bitmap(textBox1.Text);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            output1 = new Bitmap(original.Width * 2, original.Height * 2);
            output2 = new Bitmap(original.Width * 2, original.Height * 2);
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                Color color;
                for (int i = 0; i < original.Width; i++)
                for (int j = 0; j < original.Height; j++)
                    {
                        color = original.GetPixel(i, j);
                        for (int x = 0; x < 4; x++) pattern[x] = random.Next(0, 5);

                        output1.SetPixel(i * 2, j * 2, patterns[pattern[0]][0]);
                        output1.SetPixel(i * 2 + 1, j * 2, patterns[pattern[1]][1]);
                        output1.SetPixel(i * 2, j * 2 + 1, patterns[pattern[2]][2]);
                        output1.SetPixel(i * 2 + 1, j * 2 + 1, patterns[pattern[3]][3]);

                        if (color.Name == "ff000000")
                        {
                            output2.SetPixel(i * 2, j * 2, patterns[Math.Abs(pattern[0] - 5)][0]);
                            output2.SetPixel(i * 2 + 1, j * 2, patterns[Math.Abs(pattern[1] - 5)][1]);
                            output2.SetPixel(i * 2, j * 2 + 1, patterns[Math.Abs(pattern[2] - 5)][2]);
                            output2.SetPixel(i * 2 + 1, j * 2 + 1, patterns[Math.Abs(pattern[3] - 5)][3]);
                        }
                        else
                        {
                            output2.SetPixel(i * 2, j * 2, patterns[pattern[0]][0]);
                            output2.SetPixel(i * 2 + 1, j * 2, patterns[pattern[1]][1]);
                            output2.SetPixel(i * 2, j * 2 + 1, patterns[pattern[2]][2]);
                            output2.SetPixel(i * 2 + 1, j * 2 + 1, patterns[pattern[3]][3]);
                        }                       
                    }
            }
            pictureBox1.Image = output1;
            pictureBox2.Image = output2;
            
        }

        public static Bitmap Decrypt(Bitmap o1, Bitmap o2)
        {
            Bitmap output = new Bitmap(o1.Width, o2.Height);
            for (int width = 0; width < o1.Width; width++)
                for (int height = 0; height < o1.Height; height++)
                {
                    if ((o1.GetPixel(width, height).Name == "ff000000" || o2.GetPixel(width, height).Name == "ff000000"))
                    {
                        output.SetPixel(width, height, Color.Black);
                    }
                    else
                        output.SetPixel(width, height, Color.White);
                }
            return output;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Decrypt(output1, output2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
