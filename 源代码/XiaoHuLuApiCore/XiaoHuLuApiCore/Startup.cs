﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IServices.Authority.IServices;
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
using Services.Authority.Services;

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

            ///设置返回的json字符串字母开头为大写
            services.AddMvc().AddJsonOptions(Options => { Options.SerializerSettings.ContractResolver = new DefaultContractResolver(); });

            //说明
            services.AddSingleton<IServices.ExplainsIServices,Services.ExplainsServices>();

            //用户
            services.AddSingleton<IServices.IAuthority.IUserServices,Services.Authority.Services.UsersServices>();

            //角色
            services.AddSingleton<IServices.IAuthority.IRoleServices, Services.Authority.RoleServices>();

            //题库
            services.AddSingleton<IServices.IExaminationServices.IQuestionBankServices, Services.ExaminationServices.QuestionBankServices>();

            //前台题库
            services.AddSingleton<IAnswer, Answer>();

            //角色操作
            services.AddSingleton<IServices.IAuthority.IRoleServices, Services.Authority.RoleServices>();

            //考生操作
            services.AddSingleton<IServices.Examination.IServices.IExamineeServices, Services.Examination.Services.ExamineeServices>();

            //权限操作
            services.AddSingleton<IPermissionsServices, PermissionsServices>();
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
