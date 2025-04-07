using Microsoft.AspNetCore.Components;
using ProductModel;
using System.Net.Http.Json;

namespace RAD30223Week8BlazorAppS00238716.Pages
{
    public partial class GrnList : ComponentBase
    {
        [Inject] public HttpClient _httpClient { get; set; }

        List<GRN> GRNs;

        protected override async Task OnInitializedAsync()
        {
            GRNs = await _httpClient.GetFromJsonAsync<List<GRN>>("api/GRN");
        }

        protected void ViewDetails(int id)
        {
            Navigation.NavigateTo($"/grn/{id}");
        }
    }
}
