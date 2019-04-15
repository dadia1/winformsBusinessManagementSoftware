using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessManagementSoftware
{
    public partial class BMSoftware : Form
    {
        static internal List<Incomes> WriteAndReadIncomeArray = new List<Incomes>();
        static internal List<Expenses> WriteAndReadExpenseArray = new List<Expenses>();
        private int value;
        private double _expensess;
        private double _incoms;
        static internal bool? monthOrYearExpenss = null;
        static internal int? monthOrYearIncomes = null;
        static internal string printEx = null;
        static internal string printIn = null;
        private int writeAfterRead = 1;

        public BMSoftware()
        {
            InitializeComponent();
        }

        private void BMSoftware_Load(object sender, EventArgs e)
        {
            string line;

            MessageBox.Show("All rights reserved © \n to \n ELIYAHU DADIA.", "הודעה חשובה");

            //read expensse.

            if (File.Exists("Report expensess.txt"))
            {
                TextReader _txtReaderExpensess = new StreamReader("Report expensess.txt", Encoding.UTF8);

                while ((line = _txtReaderExpensess.ReadLine()) != null) //0 first line
                {
                    Expenses newExp = new Expenses();
                    newExp._dateTimePickerExpenss = line;

                    line = _txtReaderExpensess.ReadLine(); //1
                    newExp.expensessAmount = Double.Parse(line);

                    line = _txtReaderExpensess.ReadLine(); //2
                    newExp.txtDescripitionExpense = line;

                    line = _txtReaderExpensess.ReadLine(); //3
                    newExp.refundExpenses = Double.Parse(line);

                    // do nothing with line becuase it is just separator ----
                    line = _txtReaderExpensess.ReadLine(); //4

                    WriteAndReadExpenseArray.Add(newExp);
                }

                _txtReaderExpensess.Close();
            }

            //read incomes.

            if (File.Exists("Report incoms.txt"))
            {
                TextReader _txtReaderIncoms = new StreamReader("Report incoms.txt", Encoding.UTF8);

                while ((line = _txtReaderIncoms.ReadLine()) != null) //0 first line
                {
                    Incomes newInc = new Incomes();
                    newInc._dateTimePickerIncomes = line;

                    line = _txtReaderIncoms.ReadLine(); //1
                    newInc.incomesAmount = Double.Parse(line);

                    line = _txtReaderIncoms.ReadLine(); //2
                    newInc.txtDescripitionIcomes = line;

                    // do nothing with line becuase it is just separator ----
                    line = _txtReaderIncoms.ReadLine(); //3

                    WriteAndReadIncomeArray.Add(newInc);
                }

                _txtReaderIncoms.Close();
            }

            writeAfterRead++;
        }

        private void btnExpens_Click(object sender, EventArgs e)
        {
            Expenses exp = new Expenses();

            string Expensess = txtExpensePlusVat.Text;

            if (dateTimePickerExpenss.Checked == true)
            {
                if (cboExpensKind.SelectedIndex != -1)
                {
                    value = cboExpensKind.SelectedIndex;

                    if (double.TryParse(Expensess, out _expensess))
                    {
                        lblMessageExpense.Text = null;

                        exp._dateTimePickerExpenss = dateTimePickerExpenss.Value.ToString("MM/yyyy");
                        exp.expensessAmount = _expensess;

                        switch (value)
                        {
                            case 0:
                                exp.txtDescripitionExpense = " החזר מלא = " + txtDescripitionExpense.Text;
                                //החזר מס
                                exp.refundExpenses = _expensess;
                                break;

                            case 1:
                                exp.txtDescripitionExpense = "אין החזר  " + txtDescripitionExpense.Text;
                                //החזר מס
                                exp.refundExpenses = 0;
                                break;

                            case 2:
                                exp.txtDescripitionExpense = "החזר 45% = " + txtDescripitionExpense.Text;
                                //החזר מס
                                exp.refundExpenses = _expensess * 0.45;
                                break;

                            case 3:
                                exp.txtDescripitionExpense = "החזר 66% = " + txtDescripitionExpense.Text;
                                //החזר מס
                                exp.refundExpenses = _expensess * 0.66;
                                break;

                            case 4:
                                exp.txtDescripitionExpense = "החזר 20% = " + txtDescripitionExpense.Text;
                                //החזר מס
                                exp.refundExpenses = _expensess * 0.2;
                                break;

                            default:
                                break;
                        }

                        //saving to the list.
                        WriteAndReadExpenseArray.Add(exp);

                        //message saving to the list.
                        lblExpenseMsgResult.Text = ":) ההוצאה נשמרה במערכת";

                        //Refresh expense.
                        txtDescripitionExpense.Clear();
                        txtExpensePlusVat.Clear();
                        cboExpensKind.SelectedIndex = -1;
                        lblCboExpenssKind.Text = "";
                        lblDateTimePicker.Text = "";
                        dateTimePickerExpenss.Checked = false;
                        //Refresh incom.
                        txtIncomePlusVat.Clear();
                        txtDescripitionIncome.Clear();
                        lblIncomMessage.Text = null;
                        lblIncomeResult.Text = null;
                        lblIncomeMesseageDate.Text = null;
                    }

                    else
                    {
                        lblExpenseMsgResult.Text = null;
                        lblMessageExpense.Text = "הכנס רק מספרים *";
                    }
                }

                else
                    lblCboExpenssKind.Text = "בחר סוג הוצאה";
            }

            else
                lblDateTimePicker.Text = "בחר תאריך הוצאה";
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            string Incomes = txtIncomePlusVat.Text;

            if (dateTimePickerIncome.Checked == true)
            {
                if (double.TryParse(Incomes, out _incoms))
                {
                    Incomes inc = new Incomes();
                    inc._dateTimePickerIncomes = dateTimePickerIncome.Value.ToString("MM/yyyy");
                    inc.incomesAmount = _incoms;
                    inc.txtDescripitionIcomes = "תאור הכנסה = " + txtDescripitionIncome.Text;

                    //saving to the list.
                    WriteAndReadIncomeArray.Add(inc);

                    //message saving to the list.
                    lblIncomeResult.Text = ":) ההכנסה נשמרה במערכת";

                    //Refresh expense.
                    txtDescripitionExpense.Clear();
                    txtExpensePlusVat.Clear();
                    cboExpensKind.SelectedIndex = -1;
                    lblCboExpenssKind.Text = "";
                    lblDateTimePicker.Text = "";
                    dateTimePickerExpenss.Checked = false;
                    //Refresh incom.
                    txtIncomePlusVat.Clear();
                    txtDescripitionIncome.Clear();
                    lblIncomMessage.Text = null;
                    lblIncomeMesseageDate.Text = null;
                }

                else
                {
                    lblIncomeMesseageDate.Text = null;
                    lblIncomMessage.Text = "הכנס רק מספרים *";
                }
            }

            else
            {
                lblIncomeMesseageDate.Text = "בחר תאריך הכנסה*";
            }
        }

        private void SaveDataToTxtFileFormClosing(object sender, FormClosingEventArgs e)
        {
            //write expensse.
            TextWriter txtExpens = new StreamWriter("Report expensess.txt", false);

            foreach (Expenses ex in WriteAndReadExpenseArray)
            {
                txtExpens.WriteLine(ex._dateTimePickerExpenss);
                txtExpens.WriteLine(ex.expensessAmount);
                txtExpens.WriteLine(ex.txtDescripitionExpense);
                txtExpens.WriteLine(ex.refundExpenses);
                txtExpens.WriteLine("---------------");
            }
            txtExpens.Close();
            //File.SetAttributes("Report expensess.txt", FileAttributes.Hidden);

            //write incoms.
            TextWriter txtIncoms = new StreamWriter("Report incoms.txt", false);

            foreach (Incomes inc in WriteAndReadIncomeArray)
            {
                txtIncoms.WriteLine(inc._dateTimePickerIncomes);
                txtIncoms.WriteLine(inc.incomesAmount);
                txtIncoms.WriteLine(inc.txtDescripitionIcomes);
                txtIncoms.WriteLine("---------------");
            }
            txtIncoms.Close();
            // File.SetAttributes("Report incoms.txt", FileAttributes.Hidden);
        }

        private void אודותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All rights reserved © \n to \n ELIYAHU DADIA.");
        }

        private void לחצליציאהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void הוצאותחודשי(object sender, EventArgs e)
        {
            //load form2
            BMSoftware2 form2 = new BMSoftware2();
            monthOrYearExpenss = true;
            form2.Show();
        }

        private void הוצאותשנתי(object sender, EventArgs e)
        {
            BMSoftware2 form2 = new BMSoftware2();
            //load BMSoftware2
            monthOrYearExpenss = false;
            form2.Show();
        }

        private void הכנסותחודשי(object sender, EventArgs e)
        {
            BMSoftware2 form2 = new BMSoftware2();
            monthOrYearIncomes = 0;
            //load BMSoftware2
            form2.Show();
        }

        private void הכנסותשנתי(object sender, EventArgs e)
        {
            BMSoftware2 form2 = new BMSoftware2();
            monthOrYearIncomes = 1;
            //load BMSoftware2
            form2.Show();
        }

        //print expenss month
        private void חודשיToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            BMSoftware2 form2 = new BMSoftware2();
            printEx = "PrintExpensMonth";
            form2.btnDraft.Text = "לחץ להדפסה";
            //load BMSoftware2
            form2.Show();
        }

        //print expenss year
        private void שנתיToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            BMSoftware2 form2 = new BMSoftware2();
            printEx = "PrintExpensYear";
            form2.btnDraft.Text = "לחץ להדפסה";
            //load BMSoftware2
            form2.Show();
        }

        //print income month
        private void חודשיToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            BMSoftware2 form2 = new BMSoftware2();
            printIn = "PrintIncomeMonth";
            form2.btnDraft.Text = "לחץ להדפסה";
            //load BMSoftware2
            form2.Show();
        }

        //print income year
        private void שנתיToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            BMSoftware2 form2 = new BMSoftware2();
            printIn = "PrintIncomeYear";
            form2.btnDraft.Text = "לחץ להדפסה";
            //load BMSoftware2
            form2.Show();
        }
    }
}
