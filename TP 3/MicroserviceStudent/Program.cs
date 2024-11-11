using Microsoft.EntityFrameworkCore;

namespace MicroserviceStudent
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Add db
            builder.Services.AddDbContext<StudentContext>(options =>

            options.UseNpgsql("Host=localhost;Port=5432;Database=course_db; Username=postgres; Password = root; IncludeErrorDetail = true"));
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
