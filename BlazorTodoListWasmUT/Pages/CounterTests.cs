using BlazorTodoListWasm.Store.CounterUseCase;
using Bunit;
using Bunit.TestDoubles;
using Fluxor;
using System;
using Xunit;
using Xunit.Abstractions;

namespace BlazorTodoListWasm.Pages
{
    /// <summary>
    /// These tests are written entirely in C#.
    /// Learn more at https://bunit.egilhansen.com/docs/getting-started/
    /// </summary>
    public class CounterTests : TestContext, IDisposable
    {
        private readonly ITestOutputHelper output;
        private IStore store;

        public CounterTests(ITestOutputHelper output)
        {
            this.output = output;

            // Store initialization
            this.Services.AddFluxor(config =>
            {
                config.ScanAssemblies(typeof(Program).Assembly);
            });
            this.store = this.Services.GetService(typeof(Fluxor.Store)) as IStore;
            this.store.InitializeAsync();
        }

        //public void Dispose()
        //{
        //    this.store = null;
        //    base.Dispose();
        //}

        [Fact(DisplayName = "Counter should start at Zero")]
        public void CounterStartsAtZero()
        {
            this.output.WriteLine("Test xUnit output file");

            // Arrange
            var cut = RenderComponent<Counter>();

            // Assert that content of the paragraph shows counter at zero
            cut.Find("p").MarkupMatches("<p>Current count: 0</p>");

            cut.Dispose();
        }

        [Fact(DisplayName = "Clicking on button the value should be incremented")]
        public void ClickingButtonIncrementsCounter()
        {

            // TODO why this line is needed to have the test running, race issue?
            this.JSInterop.Mode = JSRuntimeMode.Loose;

            // Arrange
            var cut = RenderComponent<Counter>();

            // Act - click button to increment counter
            cut.Find("button").Click();

            // Assert that the counter was incremented
            cut.Find("p").MarkupMatches("<p>Current count: 1</p>");

            cut.Dispose();
        }
    }
}
