namespace GithubIssues.Models
{
    public class IssueModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string UserLogin { get; set; }
        public string AssigneeLogin { get; set; }
    }
}