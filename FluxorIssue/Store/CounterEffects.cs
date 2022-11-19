using Fluxor;
using FluxorIssue.Store.Actions;

namespace FluxorIssue.Store;

public class CounterEffects
{
    [EffectMethod]
    public async Task LoadData(CounterLoadDataAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new CounterSetIsLoadingAction(true));
        
        // simulate fetching data from the server
        await Task.Delay(1000);
        var fetchedData = 69;
        
        dispatcher.Dispatch(new CounterSetValueAction(fetchedData));
        dispatcher.Dispatch(new CounterSetIsLoadingAction(false));
    }
}