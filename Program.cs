using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<EnumerableVsListBenchmark>();

public record TestRecord(Guid Id, string Name)
{
    public int Quantity { get; set; }
};

[MemoryDiagnoser]
public class EnumerableVsListBenchmark
{
    private readonly IEnumerable<TestRecord> _enumerable;

    public EnumerableVsListBenchmark()
    {
        _enumerable = Enumerable
            .Range(0, 100000)
            .Select((item, index) =>
                new TestRecord(Guid.Empty, "Record name")
                {
                    Quantity = index
                });
    }

    [Benchmark]
    public void ListTest()
    {
        var list = _enumerable.ToList();

        list.ForEach(item => item.Quantity += 1);

        foreach (var item in list)
        {
            // do nothing
        }
    }

    [Benchmark]
    public void EnumerableTest()
    {
        var list = _enumerable;

        list = list.Select(item =>
        {
            item.Quantity += 1;

            return item;
        });

        foreach (var item in list)
        {
            // do nothing
        }
    }
}
