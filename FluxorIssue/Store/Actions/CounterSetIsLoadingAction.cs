namespace FluxorIssue.Store.Actions;

public class CounterSetIsLoadingAction
{
    public bool IsLoading { get; set; }

    public CounterSetIsLoadingAction(bool isLoading)
    {
        IsLoading = isLoading;
    }
}