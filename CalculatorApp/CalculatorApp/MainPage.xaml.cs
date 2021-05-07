using CalculatorApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorApp
{
    public partial class MainPage : ContentPage
    {
        int currentstate = 1;
        double firstnumber, secondnumber;
        string mathoperator;
        string getvalue = "0";

        public MainPage()
        {
            InitializeComponent();
            OnClear(this, null);
        }

        private void OnSelectNumber(object sender, EventArgs e)
        {
            
            Button button = (Button) sender;
            String pressed = button.Text;

            if(this.getvalue == "0" || currentstate < 0)
            {
                this.getvalue = "";
                
                if (currentstate < 0)
                    currentstate *= -1;
            }
            getvalue += pressed;
            this.resulttext.Text += pressed;

            double number;
            if(double.TryParse(this.getvalue, out number))
            {
                if (currentstate == 1)
                    firstnumber = number;
                else
                {
                    secondnumber = number;
                }
                
            }
        }

        private void OnSelectOperator(object sender, EventArgs e)
        {
            currentstate = -2;
            Button button = sender as Button;
            String pressed = button.Text;
            mathoperator = pressed;
            resulttext.Text += pressed;
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            if(currentstate == 2)
            {
                var result = SimpleCalculator.OnCalculate(firstnumber, secondnumber, mathoperator);

                Post post = new Post
                {
                    Calculations = this.resulttext.Text
                };

                this.resulttext.Text = result.ToString();

                post.Answer = resulttext.Text;

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
                {
                    conn.CreateTable<Post>();
                    conn.Insert(post);
                }

                firstnumber = result;
                currentstate = -1;
            }
        }

        private void OnClear(object sender, EventArgs e)
        {
            firstnumber = 0;
            secondnumber = 0;
            currentstate = 1;
            this.resulttext.Text = "";
            this.getvalue = "";
        }

        private void OnAdd(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HistoryPage());
        }
    }
}
