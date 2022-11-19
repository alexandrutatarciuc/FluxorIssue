using Fluxor;
using FluxorIssue.Store.Actions;

namespace FluxorIssue.Store;

public class CounterReducers
{
    [ReducerMethod]
    public static CounterState OnSetValue(CounterState state, CounterSetValueAction action)
    {
        return state with
        {
            CounterValue = action.Value
        };
    }
    
    [ReducerMethod]
    public static CounterState OnSetIsLoading(CounterState state, CounterSetIsLoadingAction action)
    {
        return state with
        {
            IsLoading = action.IsLoading
        };
    }
}