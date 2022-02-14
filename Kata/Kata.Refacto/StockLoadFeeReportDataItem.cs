namespace Kata.Refacto;

public class StockLoadFeeReportDataItem
{
    public string Instrument { get; set; }
    public Benchmark Benchmark { get; set; }
    public Benchmark BenchmarkAtReportDate { get; set; }
    public double BenchmarkFeeVariation { get; set; }
    public CategoryChange CategoryChange { get; set; }

    public void ComputeCategory() => Benchmark.Category = ComputeCategory(Benchmark.Fee);

    public void ComputeCategoryAtReportDate() =>
        BenchmarkAtReportDate.Category = ComputeCategory(BenchmarkAtReportDate.Fee);

    private Category ComputeCategory(double benchmarkFee)
    {
        if (benchmarkFee <= 0.5)
        {
            return Category.GeneralCollateral;
        }
        if (benchmarkFee > 0.5 && benchmarkFee <= 2)
        {
            return Category.Special;
        }

        return Category.HardToBorrow;
    }

    public void ComputeBenchmarkFeeVariation() =>
        BenchmarkFeeVariation = (BenchmarkAtReportDate.Fee - Benchmark.Fee) / Benchmark.Fee * 100;

    public void ComputeCategoryChange()
    {
        if (Benchmark.Category == Category.GeneralCollateral && BenchmarkAtReportDate.Category == Category.Special
            || Benchmark.Category == Category.Special && BenchmarkAtReportDate.Category == Category.HardToBorrow
            || Benchmark.Category == Category.GeneralCollateral && BenchmarkAtReportDate.Category == Category.HardToBorrow)
        {
            CategoryChange = CategoryChange.Up;
        }
        else if (Benchmark.Category == Category.HardToBorrow && BenchmarkAtReportDate.Category == Category.Special
            || Benchmark.Category == Category.Special && BenchmarkAtReportDate.Category == Category.GeneralCollateral
            || Benchmark.Category == Category.HardToBorrow && BenchmarkAtReportDate.Category == Category.GeneralCollateral)
        {
            CategoryChange = CategoryChange.Down;
        }
        else if (Benchmark.Category == Category.GeneralCollateral && BenchmarkAtReportDate.Category == Category.GeneralCollateral
            || Benchmark.Category == Category.Special && BenchmarkAtReportDate.Category == Category.Special
            || Benchmark.Category == Category.HardToBorrow && BenchmarkAtReportDate.Category == Category.HardToBorrow)
        {
            CategoryChange = CategoryChange.Same;
        }
    }
}