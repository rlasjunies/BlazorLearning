using Fluxor;

namespace BlazorTodoListWasm.Store.CounterUseCase
{
	public class Feature : Feature<CounterState>
	{
		public override string GetName() => nameof(CounterState);
		protected override CounterState GetInitialState() =>
			new CounterState(clickCount: 0);
	}
}