using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessManagementSoftware
{
    public partial class BMSoftware3 : Form
    {
        private int itemperpage = 0;//this is for no of item per page 
        private int totalnumber = 0;
        private Brush letterBrush = Brushes.Black;
        private BMSoftware2 BM2;
        private List<double> incomeArray = new List<double>();
        private List<double> expenssArray = new List<double>();
        static internal double incomes;
        static internal double expenss;
        private string selectedKey;
        static internal double mas;
        static internal double bituach;
        private List<double> TaxRefunds = new List<double>();
        private double _Tax;
        private double maAmYear;
        private double maAmMonth;
        public BMSoftware3(BMSoftware2 bm2)
        {
            InitializeComponent();
            BM2 = bm2;
        }

        private void BMSsoftware3_Load(object sender, EventArgs e)
        {
            //report expensses month
            if (BMSoftware.monthOrYearExpenss == true || BMSoftware.printEx == "PrintExpensMonth")
            {
                //display the titel report expensess month.
                lstBoxReport.Items.Add("דוח הוצאות חודשי");
                lstBoxReport.Items.Add("---------------------------");
                lstBoxReport.Items.Add(BM2.cboMonth.SelectedItem + "/" + BM2.cboYear.SelectedItem);
                lstBoxReport.Items.Add("---------------------------");

                //display the report expensess month.
                for (int i = 0; i < BMSoftware.WriteAndReadExpenseArray.Count; i++)
                {
                    selectedKey = ((KeyValuePair<string, string>)(BM2.cboMonth.SelectedItem)).Key;
                    if (BMSoftware.WriteAndReadExpenseArray[i] != null)
                    {
                        if (BMSoftware.WriteAndReadExpenseArray[i]._dateTimePickerExpenss == selectedKey + "/" + BM2.cboYear.SelectedItem)
                        {
                            lstBoxReport.Items.Add(BMSoftware.WriteAndReadExpenseArray[i].expensessAmount);
                            lstBoxReport.Items.Add(BMSoftware.WriteAndReadExpenseArray[i].txtDescripitionExpense);
                            expenssArray.Add(BMSoftware.WriteAndReadExpenseArray[i].refundExpenses);
                            lstBoxReport.Items.Add(Environment.NewLine);
                        }
                    }
                }

                for (int t = 0; t < BMSoftware.WriteAndReadIncomeArray.Count; t++)
                {
                    if (BMSoftware.WriteAndReadIncomeArray[t] != null)
                    {
                        if (BMSoftware.WriteAndReadIncomeArray[t]._dateTimePickerIncomes == selectedKey + "/" + BM2.cboYear.SelectedItem)
                        {
                            incomeArray.Add(BMSoftware.WriteAndReadIncomeArray[t].incomesAmount);
                        }
                    }
                }

                foreach (double _incomes in incomeArray)
                {
                    incomes += _incomes;
                }

                foreach (double _expenss in expenssArray)
                {
                    expenss += _expenss;
                }

                lstBoxReport.Items.Add(Environment.NewLine);
                lstBoxReport.Items.Add("------ סיכום -----");
                lstBoxReport.Items.Add(expenss.ToString() + " כולל מעמ ");
                lstBoxReport.Items.Add((expenss * 0.83).ToString() + " ללא מעמ ");
                lstBoxReport.Items.Add((incomes * 0.17 - expenss * 0.17).ToString() + " מעמ חודשי לתשלום");
                maAmMonth = incomes * 0.17 - expenss * 0.17;

                BituachLeomiANDmasAchnasa.Mas();
                lstBoxReport.Items.Add(mas.ToString() + " מס הכנסה חודשי לתשלום");

                BituachLeomiANDmasAchnasa.Bituach();
                lstBoxReport.Items.Add(bituach.ToString() + " ביטוח לאומי חודשי לתשלום");

                //סה"כ
                lstBoxReport.Items.Add((maAmMonth + mas + bituach).ToString() + " = סהכ מיסים חודשי. מעמ + ביטוח לאומי + מס הכנסה");

                //print expensses month
                if (BMSoftware.printEx == "PrintExpensMonth")
                {
                    //For each button click event we have to reset below two variables to 0     
                    // because every time  PrintPage event fires automatically. 

                    itemperpage = 0;
                    printPreviewDialog1.Document = printDocument1;

                    ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled
                    = false;//disable the direct print from printpreview.as when we click that Print button PrintPage event fires again.


                    DialogResult result = printPreviewDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                        printPreviewDialog1.ShowDialog();
                }
            }

            //report expensess year
            if (BMSoftware.monthOrYearExpenss == false || BMSoftware.printEx == "PrintExpensYear")
            {
                //display the titel report expensess year.
                lstBoxReport.Items.Add("דוח הוצאות שנתי");
                lstBoxReport.Items.Add("---------------------------");
                lstBoxReport.Items.Add(BM2.cboYear.SelectedItem);
                lstBoxReport.Items.Add("---------------------------");

                //display the information , report expensess year.
                for (int i = 0; i < BMSoftware.WriteAndReadExpenseArray.Count; i++)
                {
                    selectedKey = BM2.cboYear.SelectedItem.ToString();
                    if (BMSoftware.WriteAndReadExpenseArray[i] != null)
                    {
                        if (BMSoftware.WriteAndReadExpenseArray[i]._dateTimePickerExpenss.Substring(3) == selectedKey)
                        {
                            lstBoxReport.Items.Add(BMSoftware.WriteAndReadExpenseArray[i].expensessAmount);
                            lstBoxReport.Items.Add(BMSoftware.WriteAndReadExpenseArray[i].txtDescripitionExpense);
                            expenssArray.Add(BMSoftware.WriteAndReadExpenseArray[i].expensessAmount);
                            lstBoxReport.Items.Add(Environment.NewLine);
                        }
                    }
                }

                for (int j = 0; j < BMSoftware.WriteAndReadIncomeArray.Count; j++)
                {
                    if (BMSoftware.WriteAndReadIncomeArray[j] != null)
                    {
                        if (BMSoftware.WriteAndReadIncomeArray[j]._dateTimePickerIncomes.Substring(3) == selectedKey)
                        {
                            incomeArray.Add(BMSoftware.WriteAndReadIncomeArray[j].incomesAmount);
                        }
                    }
                }

                foreach (double _incomes in incomeArray)
                {
                    incomes += _incomes;
                }

                foreach (double _expenss in expenssArray)
                {
                    expenss += _expenss;
                }

                lstBoxReport.Items.Add(Environment.NewLine);
                lstBoxReport.Items.Add("------ סיכום -----");
                lstBoxReport.Items.Add(expenss.ToString() + " כולל מעמ ");
                lstBoxReport.Items.Add((expenss * 0.83).ToString() + " ללא מעמ ");
                lstBoxReport.Items.Add((incomes * 0.17 - expenss * 0.17).ToString() + " מעמ שנתי לתשלום");
                maAmYear = incomes * 0.17 - expenss * 0.17;

                BituachLeomiANDmasAchnasa.Mas();
                lstBoxReport.Items.Add(mas.ToString() + " מס הכנסה שנתי לתשלום");

                BituachLeomiANDmasAchnasa.Bituach();
                lstBoxReport.Items.Add(bituach.ToString() + " ביטוח לאומי שנתי לתשלום");

                //סה"כ
                lstBoxReport.Items.Add((maAmYear + mas + bituach).ToString() + " = סהכ מיסים שנתי. מעמ + ביטוח לאומי + מס הכנסה");

                //print expensses year
                if (BMSoftware.printEx == "PrintExpensYear")
                {
                    //For each button click event we have to reset below two variables to 0     
                    // because every time  PrintPage event fires automatically. 

                    itemperpage = 0;
                    printPreviewDialog1.Document = printDocument1;

                    ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled
                    = false;//disable the direct print from printpreview.as when we click that Print button PrintPage event fires again.


                    DialogResult result = printPreviewDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                        printPreviewDialog1.ShowDialog();
                }
            }

            //report incomes year
            if (BMSoftware.monthOrYearIncomes == 1 || BMSoftware.printIn == "PrintIncomeYear")
            {
                //display the titel report incomes year.
                lstBoxReport.Items.Add("דוח הכנסות שנתי");
                lstBoxReport.Items.Add("---------------------------");
                lstBoxReport.Items.Add(BM2.cboYear.SelectedItem);
                lstBoxReport.Items.Add("---------------------------");

                //display the information that already exists in the system , report incomes year.
                for (int i = 0; i < BMSoftware.WriteAndReadIncomeArray.Count; i++)
                {
                    selectedKey = BM2.cboYear.SelectedItem.ToString();
                    if (BMSoftware.WriteAndReadIncomeArray[i] != null)
                    {
                        if (BMSoftware.WriteAndReadIncomeArray[i]._dateTimePickerIncomes.Substring(3) == selectedKey)
                        {
                            lstBoxReport.Items.Add(BMSoftware.WriteAndReadIncomeArray[i].incomesAmount);
                            lstBoxReport.Items.Add(BMSoftware.WriteAndReadIncomeArray[i].txtDescripitionIcomes);
                            incomeArray.Add(BMSoftware.WriteAndReadIncomeArray[i].incomesAmount);
                            lstBoxReport.Items.Add(Environment.NewLine);
                        }
                    }
                }

                for (int t = 0; t < BMSoftware.WriteAndReadExpenseArray.Count; t++)
                {
                    if (BMSoftware.WriteAndReadExpenseArray[t] != null)
                    {
                        if (BMSoftware.WriteAndReadExpenseArray[t]._dateTimePickerExpenss.Substring(3) == selectedKey)
                        {
                            expenssArray.Add(BMSoftware.WriteAndReadExpenseArray[t].expensessAmount);
                            TaxRefunds.Add(BMSoftware.WriteAndReadExpenseArray[t].refundExpenses);
                        }
                    }
                }

                foreach (double _tax in TaxRefunds)
                {
                    _Tax += _tax;
                }

                foreach (double _expenss in expenssArray)
                {
                    expenss += _expenss;
                }

                foreach (double _incomes in incomeArray)
                {
                    incomes += _incomes;
                }

                maAmYear = incomes * 0.17 - expenss * 0.17;
                BituachLeomiANDmasAchnasa.Mas();
                BituachLeomiANDmasAchnasa.Bituach();
                lstBoxReport.Items.Add(Environment.NewLine);
                lstBoxReport.Items.Add("------ סיכום -----");
                lstBoxReport.Items.Add(incomes.ToString() + " כולל מעמ ");
                lstBoxReport.Items.Add((incomes * 0.83).ToString() + " ללא מעמ ");
                //רווח ברוטו שנתי ללא מעמ
                lstBoxReport.Items.Add((incomes * 0.83 - expenss * 0.83).ToString() + " רווח ברוטו שנתי ללא מעמ");
                //רווח נטו
                lstBoxReport.Items.Add((incomes - (maAmYear + (mas - _Tax) + bituach)).ToString() + " רווח נטו שנתי כולל זיכוי מס כפי המופיע בדוח ההוצאות");

                //print incomes year
                if (BMSoftware.printIn == "PrintIncomeYear")
                {
                    //For each button click event we have to reset below two variables to 0     
                    // because every time  PrintPage event fires automatically. 

                    itemperpage = 0;
                    printPreviewDialog1.Document = printDocument1;

                    ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled
                    = false;//disable the direct print from printpreview.as when we click that Print button PrintPage event fires again.


                    DialogResult result = printPreviewDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                        printPreviewDialog1.ShowDialog();
                }
            }

            //report incomes month
            if (BMSoftware.monthOrYearIncomes == 0 || BMSoftware.printIn == "PrintIncomeMonth")
            {
                //display the titel report incomes month.
                lstBoxReport.Items.Add("דוח הכנסות חודשי");
                lstBoxReport.Items.Add("---------------------------");
                lstBoxReport.Items.Add(BM2.cboMonth.SelectedItem + "/" + BM2.cboYear.SelectedItem);
                lstBoxReport.Items.Add("---------------------------");

                //display the report incomes month.
                for (int i = 0; i < BMSoftware.WriteAndReadIncomeArray.Count; i++)
                {
                    selectedKey = ((KeyValuePair<string, string>)(BM2.cboMonth.SelectedItem)).Key;
                    if (BMSoftware.WriteAndReadIncomeArray[i] != null)
                    {
                        if (BMSoftware.WriteAndReadIncomeArray[i]._dateTimePickerIncomes == selectedKey + "/" + BM2.cboYear.SelectedItem)
                        {
                            lstBoxReport.Items.Add(BMSoftware.WriteAndReadIncomeArray[i].incomesAmount);
                            lstBoxReport.Items.Add(BMSoftware.WriteAndReadIncomeArray[i].txtDescripitionIcomes);
                            lstBoxReport.Items.Add(Environment.NewLine);
                            incomeArray.Add(BMSoftware.WriteAndReadIncomeArray[i].incomesAmount);
                            lstBoxReport.Items.Add(Environment.NewLine);
                        }
                    }
                }

                for (int t = 0; t < BMSoftware.WriteAndReadExpenseArray.Count; t++)
                {
                    if (BMSoftware.WriteAndReadExpenseArray[t] != null)
                    {
                        if (BMSoftware.WriteAndReadExpenseArray[t]._dateTimePickerExpenss == selectedKey + "/" + BM2.cboYear.SelectedItem)
                        {
                            expenssArray.Add(BMSoftware.WriteAndReadExpenseArray[t].expensessAmount);
                            TaxRefunds.Add(BMSoftware.WriteAndReadExpenseArray[t].refundExpenses);
                        }
                    }
                }

                foreach (double _tax in TaxRefunds)
                {
                    _Tax += _tax;
                }

                foreach (double _expenss in expenssArray)
                {
                    expenss += _expenss;
                }

                foreach (double _incomes in incomeArray)
                {
                    incomes += _incomes;
                }

                lstBoxReport.Items.Add(Environment.NewLine);

                maAmMonth = incomes * 0.17 - expenss * 0.17;
                BituachLeomiANDmasAchnasa.Mas();
                BituachLeomiANDmasAchnasa.Bituach();

                lstBoxReport.Items.Add("------ סיכום -----");
                lstBoxReport.Items.Add(incomes.ToString() + " כולל מעמ ");
                lstBoxReport.Items.Add((incomes * 0.83).ToString() + " ללא מעמ ");
                //רווח ברוטו חודשי ללא מעמ
                lstBoxReport.Items.Add((incomes * 0.83 - expenss * 0.83).ToString() + " רווח ברוטו חודשי ללא מעמ");

                //רווח נטו
                lstBoxReport.Items.Add((incomes - (maAmMonth + (mas - _Tax) + bituach)).ToString() + " רווח נטו חודשי כולל זיכוי מס כפי המופיע בדוח ההוצאות");

                //print incomes month
                if (BMSoftware.printIn == "PrintIncomeMonth")
                {
                    //For each button click event we have to reset below two variables to 0     
                    // because every time  PrintPage event fires automatically. 

                    itemperpage = 0;
                    printPreviewDialog1.Document = printDocument1;

                    ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled
                    = false;//disable the direct print from printpreview.as when we click that Print button PrintPage event fires again.


                    DialogResult result = printPreviewDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                        printPreviewDialog1.ShowDialog();
                }
            }

            mas = 0;
            bituach = 0;
            maAmYear = 0;
            maAmMonth = 0;
            _Tax = 0;
            incomes = 0;
            expenss = 0;
            BMSoftware.monthOrYearIncomes = null;
            BMSoftware.monthOrYearExpenss = null;
            BMSoftware.printEx = null;
            BMSoftware.printIn = null;
        }

        int i = 0;
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            float currentY = 20;// declare  one variable for height measurement
            e.Graphics.DrawString("BMS", new Font("David", 5), Brushes.Black, 5, currentY);//this will print one heading/title in every page of the document
            currentY += 15;

            for (; i < lstBoxReport.Items.Count; i++)// check the number of items
            {
                e.Graphics.DrawString(lstBoxReport.Items[i].ToString(), new Font("David", 20), Brushes.Black, 50, currentY);//print each item
                currentY += 20; // set a gap between every item

                if (itemperpage < 40) // check whether  the number of item(per page) is more or not
                {
                    itemperpage += 1; // increment itemperpage by 1
                    e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added

                }

                else // if the number of item(per page) is more add one page
                {
                    itemperpage = 0; //initiate itemperpage to 0 .
                    e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                    return;
                }
            }
        }
    }
}







