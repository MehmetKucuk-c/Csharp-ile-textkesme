using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TextKesme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path;
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog txtac = new OpenFileDialog();
            txtac.Title = "Metin Belgesi Aç";
            txtac.Filter = "Metin Dosyaları(*.txt) | *.txt";
            if(txtac.ShowDialog()==DialogResult.OK)
            {
                path = txtac.FileName;
                StreamReader oku = new StreamReader(txtac.FileName);
                richTextBox1.Text = oku.ReadToEnd();
                oku.Close();
            }
            else
            {
                return;
            }
        }
        public string yazi;

        private void button1_Click(object sender, EventArgs e)
        {
            yazi = richTextBox1.Text;
            yazi = yazi.Replace("&#231;", "ç").Replace("&#246;", "ö").Replace("&#220;", "Ü").Replace("&#214;", "Ö").Replace("&#199;", "Ç").Trim().Replace("&#252;", "ü").Replace('"', ' ').Trim();
            yazi = yazi.Replace("try {", "").Replace("ol4Master.AddPoi(KoordinatDegistir(", "").Replace(", , &lt;b&gt;", "").Replace("-", "").Replace("}", "").Replace("catch (err) { ", "").Replace("console.log(", "").Replace(")", "").Replace("&lt;/br&gt;767,", "").Replace("/Content/img/icon-bus.png);", "").Replace("&lt;/b&gt;", "").Replace("Ge&#231;en Hatlar &lt;/br&gt;767, ", "").Replace("         ", "").Replace("    ", "").Replace("              ", "").Replace("                  ", "").Replace("   ", "").Replace(", , &lt;b&gt;", "").Replace("Hatlar ", "");
            yazi = yazi.Replace("&lt;/br&gt;775, ", "").Replace("/Content/img/iconbus.png;", "").Replace("&lt;/br&gt;775,778, ", "").Replace("&lt;/br&gt;729,775, ", "").Replace("&lt;/br&gt;106,729,775,792, ", "");
            yazi = yazi.Replace("&lt;/br&gt;729,775,776,789,792,804,808,814,829, ", "").Replace("&lt;/br&gt;106,729,775,776,792, ", "").Replace("&lt;/br&gt;106,708,729,775,776,792,808, ", "").Replace("&lt;/br&gt;707,729,775,776,789,792,804,808,829, ", "");
            yazi = yazi.Replace("&lt;/br&gt;106,708,729,775,776,792,808,814, ", "").Replace("&lt;/br&gt;Geçen ", "").Replace("&lt;/br&gt;776,778,829, ", "").Replace("&lt;b&gt;", "").Trim();
            yazi = yazi.Replace("\n\n", "");
            if(yazi.Contains("&#")==true)
            {
                MessageBox.Show("Unicode bulundu kontrol ediniz. Dosya yolu:\n"+path,"HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            richTextBox2.Text = yazi;
            ekle_lis.BringToFront();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DosyaOkuma();
        }
        int sayac;
        public string txt;
        public void DosyaOkuma()
        {
            string[] Deger = Regex.Split(richTextBox2.Text, "\n");
            foreach (string item in Deger)
            {
                ekle_lis.Items.Add(item);
                sayac += 1;
            }

            string[] listBoxItem = new string[ekle_lis.Items.Count];

            for (int i = 0; i < ekle_lis.Items.Count; i++)
            {
                listBoxItem[i] = ekle_lis.Items[i].ToString();

                if (i % 3 == 0)
                {
                    listBoxItem[i] = ekle_lis.Items[i].ToString().Replace("&lt;/br&gt;","").Replace("1","").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "").Replace("0", "").Replace(",", "").Replace("&lt;b&gt;", "").Replace(";","").Replace("/Content/img/iconbus.png ", "").Trim().Remove(0, 3).Trim();
                    
                }
                listBox1.Items.Add(listBoxItem[i]);
            }
            listBox1.BringToFront();
            File.WriteAllLines(path, listBox1.Items.Cast<string>().ToArray());
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval+=10;
            if(timer1.Interval>=200)
            {
                Application.Restart();
            }
        }
    }
}
