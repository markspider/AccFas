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

namespace AccFas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            List<string> accIn = new List<string>(File.ReadAllLines(openFileDialog1.FileName));
            List<Account> accOut = new List<Account>();
            List<string> res = new List<string>();
            foreach (var accStr in accIn)
            {
                Account acc = new Account
                {
                    acc = accStr,
                    count = int.Parse(accStr.Split('|')[2])
                };
                accOut.Add(acc);
            }
            // accOut.Sort();
            var sortedUsers = from u in accOut
                              orderby u.count descending //ascending
                              select u;
            //File.WriteAllLines("result.txt",accOut);
            //accOut.Clear();
            foreach (var acc in sortedUsers)
            {
                //File.AppendAllText("result.txt", acc.acc+Environment.NewLine);
                res.Add(acc.acc);
                richTextBox1.AppendText(acc.acc + Environment.NewLine);
            }
            File.WriteAllLines("result.txt", res);
        }

    }
    public class Account 
    { 
    public string acc { get; set; }
        public int count { get; set; }
    }
}
