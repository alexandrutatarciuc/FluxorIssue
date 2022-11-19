using Fluxor;

namespace FluxorIssue.Store;

[FeatureState]
public record CounterState
{
    public bool IsLoading { get; init; }
    public int CounterValue { get; init; }
}