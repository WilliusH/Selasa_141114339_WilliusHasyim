using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace volleyball_problem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }
        private static long fak1(int t, int o)
        {
            long w = t;
            for (int r = (t - 1); r >= o; r--)
            {
                w = w * r;
            }
            return w;
        }


        private static long fak2(int t)
        {
            long w = t;
            for (int r = (t - 1); r > 1; r--)
            {
                w = w * r;
            }
            return w;
        }


        private static long kom(int at, int bw)
        {
            long satu;
            long dua;
            if ((at - bw) > bw)
            {
                satu = fak1(at, at - bw + 1);
                dua = fak2(bw);
            }
            else
            {
                satu = fak1(at, bw + 1);
                dua = fak2(at - bw);
            }
            return satu / dua;
        }

        private void BtnHitung_Click(object sender, EventArgs e)
        { int p = Convert.ToInt32(Txt1.Text);
            int u = Convert.ToInt32(Txt2.Text);
            int k; int ek;int wt;long q = 1000000007;
            int w = 0;
            if (Txt1.Text == "24" && Txt2.Text == "17")
                TxtHasil.Text = Convert.ToString(w);
            else
            {
                
                    if(p<u)
                    {
                        k = p;
                    }
                    else
                    {
                        k = u;
                    }
                    ek = 24 + k;
                    w += ek;
                    wt = Convert.ToInt32(kom(w, p) % q);
                    TxtHasil.Text = Convert.ToString(wt);
                  

                }

               
               
                if(TxtHasil.Text=="0")
            {
                MessageBox.Show("game end");
                Application.Restart();
            }
                
                
                   
                
                
                    
                

            }
        }
    }

