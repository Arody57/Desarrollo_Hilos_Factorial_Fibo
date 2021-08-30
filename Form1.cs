using fibo_factorial.Recursividad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fibo_factorial
{
    public partial class Central : Form
    {
        Recursivo r = new Recursivo();
        delegate void delegado(int valor);
        public Central()
        {
            InitializeComponent();
        }
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy/MM/dd HHmmssffff");
        }
        private void btnNormal_Click(object sender, EventArgs e)
        {


            int number = Convert.ToInt32(txtNumber.Text);
            int n1 = 0;
            resultado.Text = ($"{resultado.Text}{GetTimestamp(DateTime.Now)} - Resultado Factorial:  {r.factorial(number)}\r\n");

            while (n1 < number)
            {
                resultado.Text = ($"{resultado.Text}{GetTimestamp(DateTime.Now)} - Resultado Fibonacci: {r.fibonacci(n1)}\r\n");
                n1++;
            }
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            Thread threadProcess1 = new Thread(new ThreadStart(atencionHiloFactorial));
            Thread threadProcess2 = new Thread(new ThreadStart(atencionHiloFibo));
            threadProcess1.Start();
            threadProcess2.Start();
        }

        public void atencionHiloFactorial()
        {
            int number = Convert.ToInt32(txtNumber.Text);
            for (int i = 0; i<= number; i++)
            {
                delegado fc = new delegado(hiloFactorial);
                this.Invoke(fc, i);
                Thread.Sleep(1000);
            }
        }


        public void atencionHiloFibo()  
        {
            int number2 = Convert.ToInt32(txtNumber.Text);
            for (int a = 0; a < number2; a++)
            {
            delegado fb = new delegado(hiloFibo);
            this.Invoke(fb, a);
            Thread.Sleep(1000);
            }
        }

        public void hiloFactorial(int number)
        {
          resultado.Text = ($"{resultado.Text}{GetTimestamp(DateTime.Now)} - Factorial  {number}! = {r.factorial(number)}\r\n");
        }

        public void hiloFibo(int number)
        {
          resultado.Text = ($"{resultado.Text}{GetTimestamp(DateTime.Now)} - Fibonacci = { r.fibonacci(number)}\r\n");
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSleep.Enabled = cmbMode.SelectedIndex == 0  ? false : true;
            btnNormal.Enabled = cmbMode.SelectedIndex == 1 ? false : true;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            resultado.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
