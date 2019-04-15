using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace BusinessManagementSoftware
{
    public partial class BMSoftware2 : Form
    {
        private string[] MonthListNumbers = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        private string[] MonthListNames = { "ינואר","פברואר","מרץ","אפריל"
                        ,"מאי","יוני","יולי","אוגוסט","ספטמבר","אוקטובר",
                "נובמבר","דצמבר" };
        internal Dictionary<string, string> MonthKeyandNames = new Dictionary<string, string>();

        public BMSoftware2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MessageBox.Show("בחר תאריך", "הודעת מערכת");

            //fill key and value to the dictonery list.
            for (int i = 0; i < 12; i++)
                MonthKeyandNames.Add(MonthListNumbers[i], MonthListNames[i]);

            //display months into the combo box.
            cboMonth.DataSource = new BindingSource(MonthKeyandNames, null);
            cboMonth.DisplayMember = "Value";
            cboMonth.ValueMember = "Key";

            //display years into the combo box.
            for (int i = 1980; i <= 2080; i++)
                cboYear.Items.Add(i);

            //display months and years. 
            // report month expenss = (BMSoftware.monthOrYear =  true).
            // report month incomes = (BMSoftware.monthOrYearIncomes = 0).
            //print month.
            if (BMSoftware.monthOrYearExpenss == true || BMSoftware.monthOrYearIncomes == 0
                || BMSoftware.printEx == "PrintExpensMonth" || BMSoftware.printIn == "PrintIncomeMonth")
            {
                cboMonth.Visible = true;
                lblMonth.Visible = true;
            }

            //display lonly years.
            // report year expenss = false = (BMSoftware.monthOrYear = false).
            // report year incomes = 1 = (BMSoftware.monthOrYearIncomes = 1).
            //print years.
            if (BMSoftware.monthOrYearExpenss == false || BMSoftware.monthOrYearIncomes == 1
                || BMSoftware.printEx == "PrintExpensYear" || BMSoftware.printIn == "PrintIncomeYear")
            {
                cboMonth.Visible = false;
                lblMonth.Visible = false;
            }
        }

        private void btnDraft_Click(object sender, EventArgs e)
        {
            // report monthexpenss = (BMSoftware.monthOrYear =  true).
            // report month incomes = (BMSoftware.monthOrYearIncomes = 0).
            //print month.
            if (BMSoftware.monthOrYearExpenss == true || BMSoftware.monthOrYearIncomes == 0
                || BMSoftware.printEx == "PrintExpensMonth" || BMSoftware.printIn == "PrintIncomeMonth")
            {
                if (cboMonth.SelectedItem != null && cboYear.SelectedItem != null)
                {
                    //this = Will inherit BMSoftware2 to BMSoftware3 
                    //(other way)software3.BM2 = this;
                    BMSoftware3 software3 = new BMSoftware3(this);

                    //load BMSoftware3
                    software3.Show();
                }
                else
                    MessageBox.Show("יש לבחור שנה וחודש", "הודעת מערכת");
            }

            //display lonly years.
            // report year expenss = false = (BMSoftware.monthOrYear = false).
            // report year incomes = 1 = (BMSoftware.monthOrYearIncomes = 1).
            //print years.
            if (BMSoftware.monthOrYearExpenss == false || BMSoftware.monthOrYearIncomes == 1
                || BMSoftware.printIn == "PrintIncomeYear" || BMSoftware.printEx == "PrintExpensYear")
            {
                if (cboYear.SelectedItem != null)
                {
                    //this = Will inherit BMSoftware2 to BMSoftware3 
                    BMSoftware3 software3 = new BMSoftware3(this);
                    //load BMSoftware3
                    software3.Show();
                }
                else
                    MessageBox.Show("יש לבחור שנה", "הודעת מערכת");
            }
        }
    }
}

