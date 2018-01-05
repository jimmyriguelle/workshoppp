﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContosoFieldService.Models;
using Refit;

namespace ContosoFieldService.Services
{
    public interface IJobServiceAPI
    {
        [Get("/api/job/")]
        Task<List<Job>> GetJobs();

        [Get("/api/job/{id}/")]
        Task<Job> GetJobById(string id);

        [Post("/api/job/")]
        Task<Job> CreateJob([Body] Job job);

        [Post("/api/job/{id}/")]
        Task<Job> DeleteJob(string id);
    }

    public class JobsAPIService
    {
        public async Task<Job> CreateJobAsync(Job job)
        {
            var contosoMaintenanceApi = RestService.For<IJobServiceAPI>(Helpers.Constants.BaseUrl);
            return await contosoMaintenanceApi.CreateJob(job);
        }

        public async Task<List<Job>> GetJobsAsync()
        {
            var contosoMaintenanceApi = RestService.For<IJobServiceAPI>(Helpers.Constants.BaseUrl);
            return await contosoMaintenanceApi.GetJobs();
        }

        public async Task<Job> GetJobByIdAsync(string id)
        {
            var contosoMaintenanceApi = RestService.For<IJobServiceAPI>(Helpers.Constants.BaseUrl);
            return await contosoMaintenanceApi.GetJobById(id);
        }

        public async Task<Job> DeleteJobByIdAsync(string id)
        {
            var contosoMaintenanceApi = RestService.For<IJobServiceAPI>(Helpers.Constants.BaseUrl);
            return await contosoMaintenanceApi.DeleteJob(id);
        }
    }
}