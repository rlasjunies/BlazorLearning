using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoListWasm.Store.WeatherUseCase
{
    public class ActionFetchDataEffectResult
    {
        public IEnumerable<WeatherForecast> Forecasts { get; }

        public ActionFetchDataEffectResult(IEnumerable<WeatherForecast> forecasts)
        {
            Forecasts = forecasts;
        }
    }
}
