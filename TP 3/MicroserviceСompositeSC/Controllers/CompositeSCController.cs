using Microsoft.AspNetCore.Mvc;
using MicroserviceСompositeSC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MicroserviceTeacher.Models;
using MicroserviceStudent.Models;
namespace MicroserviceСompositeSC.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CompositeSCController : ControllerBase
{
    [HttpGet]
    public string Start() 
    {
        return "Composite is run!";
    }
            private readonly string _studentServiceAddress = "https://localhost:7265/api/students";
            private readonly string _teacherServiceAddress = "https://localhost:7171/api/teachers";


            [HttpGet("teachers/{subject}")]
            public async Task<List<Teacher>> GetTeacherBySubjectAsync(string subject)
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender,
               cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    HttpResponseMessage response = await
                   client.GetAsync($"{_teacherServiceAddress}");
                    if (response.IsSuccessStatusCode)
                    {
                        List<Teacher> teachers = await
                       JsonSerializer.DeserializeAsync<List<Teacher>>(
                        await response.Content.ReadAsStreamAsync());

                        return teachers.Where(teacher =>
                        teacher.Subject
                        .Split(',')
                        .Contains(subject))
                        .ToList();
                    }
                }
                return null;
            }



            [HttpGet("students/{groupName}")]
            public async Task<List<Student>> GetStudentsByGroupAsync(string
        groupName)
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
         clientHandler.ServerCertificateCustomValidationCallback = (sender,
        cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    HttpResponseMessage response = await
                   client.GetAsync($"{_studentServiceAddress}");
                    if (response.IsSuccessStatusCode)
                    {
                        List<Student> students = await
                       JsonSerializer.DeserializeAsync<List<Student>>(
                        await response.Content.ReadAsStreamAsync());
                Console.WriteLine(students.ToList());

                        return students.Where(student => student.GroupName ==
                       groupName)
                        .ToList();
                    }
                }
                return null;
            }



        [HttpGet("rating/{groupName}")]
        public async Task<RatingOfGroup> GetAverageGroupRatingAsync(string
    groupName)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender,
           cert, chain, sslPolicyErrors) => { return true; };
            using (HttpClient client = new HttpClient(clientHandler))
            {
                HttpResponseMessage response = await
               client.GetAsync($"{_studentServiceAddress}");
                if (response.IsSuccessStatusCode)
                {
                    List<Student> students = await
                   JsonSerializer.DeserializeAsync<List<Student>>(
                    await response.Content.ReadAsStreamAsync());
                    var collection = students.Where(st => st.GroupName ==
                   groupName).ToList();
                    long ratingSum = 0;
                    foreach (var i in collection)
                        ratingSum += i.Rating;
                    return new RatingOfGroup()
                    {
                        GroupName = groupName,
                        Rating = (double)ratingSum / collection.Count
                    };
                }
            }
     return null;
        }

}






        

       
    

