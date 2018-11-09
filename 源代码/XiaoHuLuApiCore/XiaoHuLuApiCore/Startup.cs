using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IServices.IAnswerServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models;
using Newtonsoft.Json.Serialization;
using Services.AnswerServices;

namespace XiaoHuLuApiCore
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(Options => { Options.SerializerSettings.ContractResolver = new DefaultContractResolver(); });
            services.AddSingleton<IServices.ExplainsIServices,Services.ExplainsServices>();
            services.AddSingleton<IServices.IAuthority.IUserServices,Services.Authority.Services.UsersServices>();
            services.AddSingleton<IServices.IAuthority.IPermissionsServices, Services.Authority.Services.PermissionsServices>();
            services.AddSingleton<IServices.IExaminationServices.IQuestionBankServices, Services.ExaminationServices.QuestionBankServices>();
            services.AddSingleton<IAnswer, Answer>();
            services.AddSingleton<IServices.IAuthority.IRoleServices, Services.Authority.RoleServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
