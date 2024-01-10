namespace HouseholdIncomeAndExpences
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        decimal income1Percentage;
        decimal income2Percentage;

        private bool mouseDown;
        private Point lastLocation;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Validating input//
            decimal firstIncome=ValidateAndConvertTextInput(income1);
            decimal secondIncome=ValidateAndConvertTextInput(income2);
            decimal householdExpenses = ValidateAndConvertTextInput(householdMonthlyExpenses);
            decimal householdIncome=firstIncome+secondIncome;
            if (firstIncome != 0 && secondIncome != 0 && householdExpenses != 0)
            {
                //Calculating what % each person contributes to household income//
                income1Percentage = (firstIncome / householdIncome) * 100;
                income2Percentage = (secondIncome / householdIncome) * 100;
                //How much each person should pay for expenses//
                decimal income1Pays = householdExpenses * (income1Percentage / 100);
                decimal income2Pays = householdExpenses * (income2Percentage / 100);

                income1Pay.Text = $"{income1Pays:f2}";
                income2Pay.Text = $"{income2Pays:f2}";

                householdMonthlyIncome.Text = $"{householdIncome:f2}";

                if (person1percent.Visible)
                {
                    person1percent.Visible = false;
                    person2Percent.Visible = false;
                    percentageButton.Text = "Show Percentage";
                }

            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (income1Percentage != 0 && income2Percentage != 0&&percentageButton.Text == "Show Percentage")
            {
               person1percent.Visible = true;
               person2Percent.Visible = true;
               person1percent.Text = $"{income1Percentage:f2} %";
               person2Percent.Text = $"{income2Percentage:f2} %";
               percentageButton.Text = "Hide Percentage";
            }
            else
            {
                percentageButton.Text = "Show Percentage";
                person1percent.Visible = false;
                person2Percent.Visible = false;
            }
            
            
        }

        private decimal ValidateAndConvertTextInput(TextBox box)
        {
            string text=box.Text;
            decimal result = 0;
            if (!Decimal.TryParse(text,out result))
            {
                if (text == string.Empty)
                {
                    box.Text = "Must be filled in!";
                }
                else
                {
                    box.Text = "Not a number!";
                    return result;
                }
                
            }
           
            return result;
        }

        private void person1IncomeClear_Click(object sender, EventArgs e)
        {
            income1.Text=String.Empty;
        }

        private void person2IncomeClear_Click(object sender, EventArgs e)
        {
            income2.Text = String.Empty;
        }

        private void householdExpensesClear_Click(object sender, EventArgs e)
        {
            householdMonthlyExpenses.Text = String.Empty;
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            income1.Text = String.Empty;
            income2.Text = String.Empty;
            income1Pay.Text = String.Empty;
            income2Pay.Text= String.Empty;
            income2Percentage = 0;
            income1Percentage = 0;
            person1percent.Text = String.Empty;
            person2Percent.Text= String.Empty;
            percentageButton.Text = "Show Percentage";
            householdMonthlyExpenses.Text = String.Empty;
            householdMonthlyIncome.Text = String.Empty;
        }

        private void closeProgramBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}