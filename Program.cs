using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<EnumerableVsListBenchmark>();

public record TestRecord(Guid id, string name)
{
    public int quantity { get; set; }
};

[MemoryDiagnoser]
public class EnumerableVsListBenchmark
{
    private static IEnumerable<TestRecord> enumerable = Enumerable.Empty<TestRecord>();

    public EnumerableVsListBenchmark()
    {
        enumerable = Enumerable
            .Range(0, 100000)
            .Select((item, index) =>
                new TestRecord(Guid.Empty, "Record name")
                {
                    quantity = index
                });
    }

    [Benchmark]
    public void ListTest()
    {
        var list = enumerable.ToList();

        list.ForEach(item => item.quantity += 1);

        foreach (var item in list)
        {
            // do nothing
        }
    }

    [Benchmark]
    public void EnumerableTest()
    {
        var list = enumerable;

        list = list.Select(item =>
        {
            item.quantity += 1;

            return item;
        });

        foreach (var item in list)
        {
            // do nothing
        }
    }
}
