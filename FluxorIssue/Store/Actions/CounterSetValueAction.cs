namespace FluxorIssue.Store.Actions;

public class CounterSetValueAction
{
    public int Value { get; set; }

    public CounterSetValueAction(int value)
    {
        Value = value;
    }
}