using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace RSA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int fun(int p, int a, int b)
        {
            int s = 1;
            for (int i = 1; i <= b; i++)
            {
               
                s = (s * a) % p;
            }
            return s;
        }

        void extendedEuclidForA(int a, int b, int _x, int _y, int _d)
        {

            int q, r;
            int x0 = 1;
            int x1 = 0;
            int y0 = 0;
            int y1 = 1;

            if (b == 0)
            {
                return;
            }

            while (b > 0)
            {
                q = a / b;
                r = a % b;

                a = b;
                b = r;

                _x = x1;
                _y = y1;

                x1 = x0 - q * _x;
                x0 = _x;

                y1 = y0 - q * _y;
                y0 = _y;
            }

            _d = a;
            _x = x0;
            _y = y0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string str1, str2;
            Random myrandom = new Random();
            int p = 79, q = 23, n, f,a, b=1,k;
            //Label A;
            n = p * q;
            f=(p-1)*(q-1);

           
        A:
            b = 1;
            a = myrandom.Next(f);
            while (b < f)
            {
                if ((b * a) % f == 1)
                    break;
                b = b + 1;
            }
            if (b == f) goto A;
            //
            //
            //
            str1 = textBox1.Text;
            textBox2.Text = "";
            textBox3.Text = "";
            for (int i = 0; i < str1.Length; i++)
            {
                k = (int)str1[i];
                //шифровка
                k = fun(n,k,a);
                textBox2.Text=textBox2.Text+k.ToString()+".";
                //дешифровка
                k = fun(n,k,b);
                textBox3.Text = textBox3.Text + (char)k;
             
            }

        }
    }
}
