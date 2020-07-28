using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorServerStateManagement.Core.Services
{
    public class CounterStateService
    {
        private IJSRuntime _js;
        public CounterStateService(IJSRuntime js)
        {
            _js = js;
        }
        public int Count { get; internal set; }
        public void Increment()
        {
            Count += 1;
            SetCountState();
        }

        public void Decrement()
        {
            Count -= 1;
            SetCountState();
        }


        public async Task GetCountState()
        {
            var countState = await _js.InvokeAsync<object>("stateManager.load", nameof(Count));
            if (countState != null)
            {
                countState = Regex.Replace(countState.ToString(), "[^0-9-]+", string.Empty);
                Count = Int32.Parse((string)countState);
            }

        }

        public async Task ClearState()
        {
            await _js.InvokeAsync<object>("stateManager.remove", nameof(Count));
            Count = 0;
        }

        private async void SetCountState()
        {
            await _js.InvokeVoidAsync("stateManager.save", nameof(Count), Count);
        }
    }
}
