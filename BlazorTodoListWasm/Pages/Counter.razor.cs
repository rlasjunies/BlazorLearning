using Fluxor;
using Microsoft.AspNetCore.Components;
using BlazorTodoListWasm.Store.CounterUseCase;
using static Microsoft.JSInterop.JSRuntime;
using Microsoft.JSInterop;
using Fluxor.Blazor.Web.Components;


//Note: This is required to ensure the component re-renders whenever its state changes. 
//    If you are unable to descend from this component, you can instead subcribe to the 
//    IState.StateChanged event and execute InvokeAsync(StateHasChanged). If you do use the event, 
//    remember to implement IDisposable and unsubscribe from the event too, otherwise your app will leak memory.

namespace BlazorTodoListWasm.Pages
{
    public partial class Counter
    {
        [Inject]
        protected IJSRuntime ijsRuntime { get; set; }

        [Inject]
        private IState<CounterState> CounterState { get; set; }

        [Inject]
        private IDispatcher dispatcher { get; set; }

        private async void CounterState_StateChanged(object sender, CounterState e)
        {
            await ijsRuntime.InvokeVoidAsync("console.log", $"statechange manually an {e.ClickCount} 'IncrementationCounterAction' event");
            this.StateHasChanged();
        }

        private async void  IncrementCount()
        {
            await ijsRuntime.InvokeVoidAsync("console.log", "dispatch an 'IncrementationCounterAction' event");
            //Console.WriteLine("The app is running on WebAssembly");

            var action = new IncrementCounterAction();
            dispatcher.Dispatch(action);
        }
    }

}