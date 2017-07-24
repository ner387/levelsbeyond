using GithubIssues.Models;
using RestSharp;
using RestSharp.Extensions.MonoHttp;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace GithubIssues.Controllers
{
    public class GithubIssuesController : Controller
    {
        // GET: GithubIssues
        public ActionResult Index()
        {
            var client = new RestClient("https://api.github.com/repos/angular/angular/");

            var request = new RestRequest("issues?since="+DateTime.Now.AddDays(-7).ToString("o"), Method.GET);
            
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var issues = serializer.Deserialize<dynamic>(content);
            List<IssueModel> issueModels = new List<IssueModel>();
            foreach (var info in issues)
            {
                issueModels.Add(new IssueModel());
                issueModels[issueModels.Count-1].Body = info["body"];
                issueModels[issueModels.Count - 1].UserLogin = info["user"]["login"];
                issueModels[issueModels.Count - 1].Title = info["title"];
                if (info["assignee"] != null)
                {
                    issueModels[issueModels.Count - 1].AssigneeLogin = info["assignee"]["login"];
                }
            }           

            return View(issueModels);
        }        
    }
}
