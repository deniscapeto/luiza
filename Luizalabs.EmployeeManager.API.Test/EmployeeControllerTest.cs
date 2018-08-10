﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http.Results;
using Luizalabs.EmployeeManager.API.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Luizalabs.EmployeeManager.API.Test
{
    [TestClass]
    public class EmployeeControllerTest
    {
        string apiUrl = "http://localhost:8000/Luizalabs.EmployeeManager.API/";

        [TestMethod]
        public void List_ShouldReturnHTTPOK200()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/javascript"));
            var response = client.GetAsync("employee/?page_size=1&page=2", HttpCompletionOption.ResponseContentRead).Result;
            Assert.AreEqual(System.Net.HttpStatusCode.OK,response.StatusCode);
        }

        [TestMethod]
        public void Create_ShouldReturnHTTPCreated201()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/javascript"));

            var requestData = new {
                name = "Renato",
                email = "renato@gmail.com",
                department = "TI" };

            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            var response = client.PostAsync("employee/", content).Result;
            Assert.AreEqual(System.Net.HttpStatusCode.Created,response.StatusCode );
        }

        [TestMethod]
        public void Delete_ShouldReturnHTTPOk200()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            var employeeId = 1;

            var response = client.DeleteAsync($"employee/{ employeeId }").Result;
            Assert.AreEqual(System.Net.HttpStatusCode.OK,response.StatusCode);
        }
    }
}
