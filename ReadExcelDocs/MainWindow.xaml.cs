﻿using System.Collections.Generic;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;
namespace ReadExcelDocs
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Create a list of accounts.
        Account data = new Account();
        

        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void btnBrowes_Click(object sender, RoutedEventArgs e)
        {
           data.ID = 3456;
            data.Balance = 546.24;

            var excelApp = new Excel.Application();
            excelApp.Visible = true;

            excelApp.Workbooks.Add();

            Excel.Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            workSheet.Cells[1, "A"] = "4435";
            workSheet.Cells[1, "B"] = "453";
            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();


        }

        private void excelbtn_Click(object sender, RoutedEventArgs e)
        {
            var excelApp = new Excel.Application { Visible = true };

            excelApp.Workbooks.Open(@"E:\first.xlsx");

            Excel.Worksheet workSheet = (Excel.Worksheet) excelApp.ActiveSheet;

            Excel.Range range = workSheet.Range[rangeRow.Text,rangeCol.Text];

            int rc = range.Rows.Count;
            int cc = range.Columns.Count;

            int rCnt, cCnt;
            string str;
            output.Text = string.Empty;
            for (rCnt = 1; rCnt <= rc; rCnt++)
            {
                for (cCnt = 1; cCnt <= cc; cCnt++)
                {
                    str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                    output.Text += str + "\n";
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var excelApp = new Excel.Application { Visible = true };

            excelApp.Workbooks.Open(@"E:\second.xlsx");

            Excel.Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            Excel.Range range = workSheet.Range[rangeRow.Text, rangeCol.Text];

            int rc = range.Rows.Count;
            int cc = range.Columns.Count;

            int rCnt, cCnt;
            string str;
            output.Text = string.Empty;
            for (rCnt = 1; rCnt <= rc; rCnt++)
            {
                for (cCnt = 1; cCnt <= cc; cCnt++)
                {
                    str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                    output.Text += str + "\n";
                }
            }
        }
    }

    // Account Class
    public class Account
    {
        public int ID { get; set; }
        public double Balance { get; set; }
    }
}
