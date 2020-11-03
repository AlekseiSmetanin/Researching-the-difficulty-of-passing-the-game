using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Исследование_сложности_прохождения_игры
{
    public partial class Form1 : Form
    {
        private Data data;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    data = new Data(openFileDialog1.FileName);
                    label1.Text = data.ToString();

                    for (int i = 0; i < data.ChartData.Length; i++)
                    {
                        chart1.Series[0].Points.AddXY(i, data.ChartData[i]);
                    }
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
