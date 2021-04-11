using Fluxor;
using Microsoft.AspNetCore.Components;
using BlazorTodoListWasm.Store.CounterUseCase;
using static Microsoft.JSInterop.JSRuntime;
using Microsoft.JSInterop;

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

        private async void  IncrementCount()
        {
            await ijsRuntime.InvokeVoidAsync("console.log", "dispatch an 'IncrementationCounterAction' event");
            //Console.WriteLine("The app is running on WebAssembly");

            var action = new IncrementCounterAction();
            dispatcher.Dispatch(action);
        }
    }

}