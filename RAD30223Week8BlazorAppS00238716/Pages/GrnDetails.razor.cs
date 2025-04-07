using Microsoft.AspNetCore.Components;
using ProductModel;
using System.Net.Http.Json;

namespace RAD30223Week8BlazorAppS00238716.Pages
{
    public partial class GrnDetails : ComponentBase
    {
        [Inject] public HttpClient _HttpClient { get; set; }
        [Parameter] public int Id { get; set; }

        protected GRN GRN;

        protected override async Task OnInitializedAsync()
        {
            GRN = await _HttpClient.GetFromJsonAsync<GRN>($"api/GRN/{Id}");
        }
    }
}
