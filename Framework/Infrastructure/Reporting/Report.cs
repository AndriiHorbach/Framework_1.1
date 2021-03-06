﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Framework.Reporting
{
   public class Report
    {
        private string BrowserType;
        private string url;
        private DateTime date;
        private FileStream fs;
        private StringBuilder reportcsv;
        private string filePath;
        private string fileName;

        public Report(string BrowserType, string url)
        {
            this.BrowserType = BrowserType;
            this.url = url;
            date = DateTime.Now;
            fileName = date.Date.Date.ToShortDateString() + date.TimeOfDay.Hours.ToString() + date.TimeOfDay.Minutes.ToString();
            reportcsv = new StringBuilder();
            filePath = @"C:\OTHER\New folder" + fileName + ".csv";
            createCsvFile();
        }
        private void createCsvFile()
        {
            reportcsv.Append("StepDescription,");
            reportcsv.Append("Pass/Fail,");
            reportcsv.Append("Exception");
            File.AppendAllText(filePath, reportcsv.ToString());
        }
        public void addLine(string description, string result, string exception)
        {
            reportcsv.Append(Environment.NewLine);
            reportcsv.Append(description + ",");
            reportcsv.Append(result + ",");
            reportcsv.Append(exception + ",");
            reportcsv.Append(Environment.NewLine);
            File.WriteAllText(filePath, reportcsv.ToString());
        }
    }
}
