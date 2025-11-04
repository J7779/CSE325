using System;
using System.IO;
using System.Text;

public class Program
{
    public static void Main()
    {
        string directoryPath = "SalesData";
        string reportFilePath = "SalesSummary.txt";
        GenerateSalesSummaryReport(directoryPath, reportFilePath);
    }

    public static void GenerateSalesSummaryReport(string directoryPath, string reportFilePath)
    {
        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Directory does not exist.");
            return;
        }

        var salesFiles = Directory.GetFiles(directoryPath, "*.txt");
        decimal totalSales = 0;
        var details = new StringBuilder();

        foreach (var file in salesFiles)
        {
            if (decimal.TryParse(File.ReadAllText(file).Trim(), out decimal sales))
            {
                totalSales += sales;
                details.AppendLine($"  {Path.GetFileName(file)}: {sales:C}");
            }
        }

        var report = new StringBuilder();
        report.AppendLine("Sales Summary");
        report.AppendLine("----------------------------");
        report.AppendLine($"Total Sales: {totalSales:C}");
        report.AppendLine();
        report.AppendLine("Details:");
        report.Append(details);

        File.WriteAllText(reportFilePath, report.ToString());
        Console.WriteLine("Sales summary report generated.");
    }
}