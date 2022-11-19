using System.Reflection;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace FluxorIssue;

public abstract class MyComponentBase : OwningComponentBase, IDisposable
{
    private readonly List<IStateChangedNotifier> _fluxorStates = new();
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            RegisterFluxorStates();
        }
    
        await base.OnAfterRenderAsync(firstRender);
    }

    private void RegisterFluxorState(IStateChangedNotifier state)
    {
        state.StateChanged += StateChanged;
    }

    private void RegisterFluxorStates()
    {
        var properties = GetType()?.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        if (properties == null)
        {
            return;
        }

        foreach (var propertyInfo in properties.ToList())
        {
            if (propertyInfo.PropertyType.Name.Contains("IState"))
            {
                var value = propertyInfo.GetValue(this);
                if (value is IStateChangedNotifier stateChangedNotifier)
                {
                    _fluxorStates.Add(stateChangedNotifier);
                    RegisterFluxorState(stateChangedNotifier);
                }
            }
        }
    }

    private async void StateChanged(object? sender, EventArgs args)
    {
        await InvokeAsync(StateHasChanged);
    }

    void IDisposable.Dispose()
    {
        foreach (var state in _fluxorStates)
        {
            state.StateChanged -= StateChanged;
        }
    }
}