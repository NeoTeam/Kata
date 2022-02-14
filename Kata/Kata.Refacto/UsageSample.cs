namespace Kata.Refacto;

public static class UsageSample
{
    public static StockLoadFeeReportDataItem GetStockLoanFeeReport(
        string instrumentName,
        double benchmarkFee,
        double benchmarkAtReportDate)
    {
        var dataItem = new StockLoadFeeReportDataItem
        {
            Instrument = instrumentName,
            Benchmark = new Benchmark
            {
                Fee = benchmarkFee * 100
            },
            BenchmarkAtReportDate = new Benchmark
            {
                Fee = benchmarkAtReportDate * 100
            }
        };

        dataItem.ComputeBenchmarkFeeVariation();
        dataItem.ComputeCategoryAtReportDate();
        dataItem.ComputeCategory();
        dataItem.ComputeCategoryChange();

        return dataItem;
    }
}