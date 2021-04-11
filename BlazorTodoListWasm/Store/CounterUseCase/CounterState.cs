
namespace BlazorTodoListWasm.Store.CounterUseCase
{

	public class CounterState
	{
        public CounterState(int clickCount)
        {
            ClickCount = clickCount;
        }

        public int ClickCount { get; }
    }
}
