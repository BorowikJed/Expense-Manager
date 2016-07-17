using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExpenseManager
{
    class Account
    {
        private static double Saldo =500.00;

        public static double getSaldo()
        {
            return Saldo;
        }

        public static void setSaldo(double s)
        {
            if (Saldo < 0)
                MessageBox.Show("Uważaj, jesteś na debecie!!!\nCzas coś zarobić ;)");
            Saldo = s;

            MainWindow mw = new MainWindow();
            String.Format("{0:F2}", mw.saldoTextBox);
        }
            
    }
        

}
