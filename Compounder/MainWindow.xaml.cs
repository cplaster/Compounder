using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Compounder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double principal = Convert.ToDouble(txtPrincipal.Text);
            double interest_rate = Convert.ToDouble(txtInterestRate.Text);
            double m_period = Convert.ToDouble(txtM_Period.Text);
            double t_period = Convert.ToDouble(txtT_Period.Text);
            double wallet_balance = principal * interest_rate;
            double compound_limit = Convert.ToDouble(txtCompoundLimit.Text);
            double monthly_contribution = Convert.ToDouble(txtMonthlyContribution.Text);
            double mod = 0;
            double transfer = 0;
            double remainder = 0;
            string s = "";
            int i = 1;
            double floor = 0;

            for(int t = 0; t < t_period; t++)
            {
                for(int m = 0; m < m_period; m++)
                {
                    wallet_balance = (principal * interest_rate) + wallet_balance;
                    s += "\nDay " + i.ToString() + "| Wallet balance: " + wallet_balance + " | ";
                    mod = wallet_balance / compound_limit;
                    if(mod >= 1)
                    {
                        floor = Math.Floor(mod);
                        transfer = (wallet_balance - (floor * compound_limit));
                        remainder = (wallet_balance - transfer);
                        wallet_balance -= remainder;
                        principal += remainder;
                        s += "Transfer " + remainder + " to principal. Wallet balance: " + wallet_balance + " | Principal: " + principal;
                        
                    }
                    i++;
                }

                principal += monthly_contribution;
            }

            txtOutput.Text = s;
        }
    }
}
