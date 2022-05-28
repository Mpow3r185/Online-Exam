using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;
using Tahaluf.PlusExam.Infra.Commom;
using Tahaluf.PlusExam.Infra.Repository;
using Tahaluf.PlusExam.Infra.Service;

namespace Tahaluf.PlusExam.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IDbContext, DbContext>();

            // Question Repository
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            // QuestionOption Repository
            services.AddScoped<IQuestionOptionRepository, QuestionOptionRepository>();
            // Result Repository
            services.AddScoped<IResultRepository, ResultRepository>();
            // Course Repository
            services.AddScoped<ICourseRepository, CourseRepository>();
            // Certificate Repository
            services.AddScoped<ICertificateRepository, CertificateRepository>();
            // Credit Card Repository
            services.AddScoped<ICreditCardRepository, CreditCardRepository>();
            // Invoice Repository
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            //Phone Number Repository
            services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();
            //Score Repository
            services.AddScoped<IScoreRepository, ScoreRepository>();
            //Correct Answer Repository
            services.AddScoped<ICorrectAnswerRepository, CorrectAnswerRepository>();
            
            
            
            // Question Service
            services.AddScoped<IQuestionService, QuestionService>();
            // QuestionOption Service
            services.AddScoped<IQuestionOptionService, QuestionOptionService>();
            // Result Service
            services.AddScoped<IResultService, ResultService>();
            // Course Service
            services.AddScoped<ICourseService, CourseService>();
            // Certificate Service
            services.AddScoped<ICertificateService, CertificateService>();
            // Credit Card Service
            services.AddScoped<ICreditCardService, CreditCardService>();
            // Invoice Service
            services.AddScoped<IInvoiceService, InvoiceService>();
            //Phone Number Service
            services.AddScoped<IPhoneNumberService, PhoneNumberService>();
            //Score Service
            services.AddScoped<IScoreService, ScoreService>();
            //Correct Answer Service
            services.AddScoped<ICorrectAnswerService, CorrectAnswerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
