using Kata.Refacto;

var stockedLoanFeeReport = UsageSample.GetStockLoanFeeReport("some instrument", 0.002d, 0.017d);

Console.WriteLine(stockedLoanFeeReport.CategoryChange);
Console.ReadLine();