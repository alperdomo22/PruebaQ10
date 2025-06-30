using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PruebaQ10Web.Models;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;

namespace PruebaQ10Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public int StudentEditId = 0;
        public bool NewStudent = false;
        public GeneralResponse<Student[]> GetAllStudents = new();
        public Student[] Students { get; set; } = [];

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var response = await client.GetAsync("student");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                GetAllStudents = JsonSerializer.Deserialize<GeneralResponse<Student[]>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new();

                Students = GetAllStudents.Data;
            }
        }

        public async Task<IActionResult> OnPostEditStudentAsync(int id)
        {
            StudentEditId = id;

            await OnGetAsync();

            // Hacer algo con el estudiante
            return Page();
        }

        public async Task<IActionResult> OnPostCancelEditStudentAsync(int id)
        {
            StudentEditId = 0;

            await OnGetAsync();

            // Hacer algo con el estudiante
            return Page();
        }

        public async Task<IActionResult> OnPostAddStudentAsync(int id)
        {
            NewStudent = true;

            await OnGetAsync();

            // Hacer algo con el estudiante
            return Page();
        }

        public async Task<IActionResult> OnPostCancelAddStudentAsync(int id)
        {
            NewStudent = false;

            await OnGetAsync();

            // Hacer algo con el estudiante
            return Page();
        }

        public async Task<IActionResult> OnPostSaveEditStudentAsync(int id, string FirstnameEditStudent, string LastnameEditStudent, int DocumentEditStudent, string EmailEditStudent)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var JsonEditStudent = JsonSerializer.Serialize(new StudentRequest
            {
                FirstName = FirstnameEditStudent,
                LastName = LastnameEditStudent,
                Document = DocumentEditStudent.ToString(),
                Email = EmailEditStudent
            });
            var content = new StringContent(JsonEditStudent, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"Student?updateStudentId={id}", content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                GeneralResponse<Student> SaveEditStudent = JsonSerializer.Deserialize<GeneralResponse<Student>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new();

                if (SaveEditStudent.Success)
                {
                    StudentEditId = 0;
                    await OnGetAsync();
                }
            }

            // Hacer algo con el estudiante
            return Page();
        }

        public async Task<IActionResult> OnPostSaveNewStudentAsync(string FirstnameNewStudent, string LastnameNewStudent, int DocumentNewStudent, string EmailNewStudent)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var JsonEditStudent = JsonSerializer.Serialize(new StudentRequest
            {
                FirstName = FirstnameNewStudent,
                LastName = LastnameNewStudent,
                Document = DocumentNewStudent.ToString(),
                Email = EmailNewStudent
            });
            var content = new StringContent(JsonEditStudent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"Student", content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                GeneralResponse<Student> SaveNewStudent = JsonSerializer.Deserialize<GeneralResponse<Student>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new();

                if (SaveNewStudent.Success)
                {
                    StudentEditId = 0;
                    await OnGetAsync();
                }
            }

            // Hacer algo con el estudiante
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveStudentAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var response = await client.DeleteAsync($"Student?removeStudentId={id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                GeneralResponse<int> RemoveStudent = JsonSerializer.Deserialize<GeneralResponse<int>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new();

                if (RemoveStudent.Success)
                {
                    StudentEditId = 0;
                    await OnGetAsync();
                }
            }

            // Hacer algo con el estudiante
            return Page();
        }
    }
}
