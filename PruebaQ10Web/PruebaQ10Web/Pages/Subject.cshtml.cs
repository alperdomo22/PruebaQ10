using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PruebaQ10Web.Models;
using System.Text;
using System.Text.Json;

namespace PruebaQ10Web.Pages
{
    public class SubjectModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SubjectModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public int SubjectEditId = 0;
        public bool NewSubject = false;

        public GeneralResponse<Subject[]> GetAllSubject = new();
        public Subject[] Subjects { get; set; } = [];

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var response = await client.GetAsync("subject");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                GetAllSubject = JsonSerializer.Deserialize<GeneralResponse<Subject[]>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new();

                Subjects = GetAllSubject.Data;
            }
        }

        public async Task<IActionResult> OnPostEditSubjectAsync(int id)
        {
            SubjectEditId = id;

            await OnGetAsync();

            // Hacer algo con el estudiante
            return Page();
        }

        public async Task<IActionResult> OnPostCancelEditSubjectAsync(int id)
        {
            SubjectEditId = 0;

            await OnGetAsync();

            // Hacer algo con el estudiante
            return Page();
        }

        public async Task<IActionResult> OnPostAddSubjectAsync(int id)
        {
            NewSubject = true;

            await OnGetAsync();

            // Hacer algo con el estudiante
            return Page();
        }

        public async Task<IActionResult> OnPostCancelAddSubjectAsync(int id)
        {
            NewSubject = false;

            await OnGetAsync();

            // Hacer algo con el estudiante
            return Page();
        }

        public async Task<IActionResult> OnPostSaveEditSubjectAsync(int id, string NameEditSubject, string CodeEditSubject, int CreditsEditSubject)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var JsonEditSubject = JsonSerializer.Serialize(new SubjectRequest
            {
                Name = NameEditSubject,
                Code = CodeEditSubject,
                Credits = CreditsEditSubject
            });
            var content = new StringContent(JsonEditSubject, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"Subject?updateSubjectId={id}", content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                GeneralResponse<Subject> SaveEditSubject = JsonSerializer.Deserialize<GeneralResponse<Subject>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new();

                if (SaveEditSubject.Success)
                {
                    SubjectEditId = 0;
                    await OnGetAsync();
                }
            }

            // Hacer algo con el estudiante
            return Page();
        }

        public async Task<IActionResult> OnPostSaveNewSubjectAsync(string NameNewSubject, string CodeNewSubject, int CreditsNewSubject)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var JsonEditSubject = JsonSerializer.Serialize(new SubjectRequest
            {
                Name = NameNewSubject,
                Code = CodeNewSubject,
                Credits = CreditsNewSubject
            });
            var content = new StringContent(JsonEditSubject, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"Subject", content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                GeneralResponse<Subject> SaveNewSubject = JsonSerializer.Deserialize<GeneralResponse<Subject>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new();

                if (SaveNewSubject.Success)
                {
                    SubjectEditId = 0;
                    await OnGetAsync();
                }
            }

            // Hacer algo con el estudiante
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveSubjectAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var response = await client.DeleteAsync($"Subject?removeSubjectId={id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                GeneralResponse<int> RemoveSubject = JsonSerializer.Deserialize<GeneralResponse<int>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new();

                if (RemoveSubject.Success)
                {
                    SubjectEditId = 0;
                    await OnGetAsync();
                }
            }

            // Hacer algo con el estudiante
            return Page();
        }
    }
}
