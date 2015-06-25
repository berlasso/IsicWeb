using MPBA.Jira;
using MPBA.Jira.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIC.Services
{
    public class JiraService : IJiraService
    {
        JiraClient<IssueFields> jira;
        
        public JiraService() 
        {
            jira = new JiraClient<IssueFields>("http://jira-test.mpba.gov.ar", "usuariorestapi", "usuariorestapi");
        }
        //public void CreateIssue(string projectKey,string issueType, string issueFields)
        //{
        //    jira.CreateIssue(projectKey,issueType,issueFields);
        //}
        public Issue<IssueFields> CreateIssue(string codigoBarra)
        {
            var issues = jira.CreateIssue("IG", "Task", new IssueFields { summary = codigoBarra });
            return issues;
        }
        public Issue<IssueFields> UpdateIssue(Issue<IssueFields> issue)
        {
            //var issues = jira.CreateIssue("IG", "Task", new IssueFields { summary = codigoBarra });
            
            var issues = jira.UpdateIssue(issue);
            return issues;
        }
        public Issue<IssueFields> GetIssue(string codigoBarra)
        {
            Issue<IssueFields> issue = null;
            var issues = GetIssuesByQuery("IG", "TASK", "summary ~ \"" + codigoBarra + "\"");
            if (issues != null)
                issue = issues.First();
           
            return issue;
        }
        
        
        public Issue<IssueFields> TransitionIssue(Issue<IssueFields> issue, Transition transition)
        {
            var issues = jira.TransitionIssue(issue, transition);
            return issues;
        }
        public IEnumerable<Issue<IssueFields>> GetIssues() 
        {
            var issues = jira.GetIssues("IG", "Task");
            return issues;
        }
        //public Issue<IssueFields> GetIssue(string codigoBarra)
        //{
        //    var issue = jira.
        //    return issue;
        //}
        public IEnumerable<Status> GetStatuses()
        {
            var statuses = jira.GetStatuses();
            return statuses;
        }

        public IEnumerable<Issue<IssueFields>> GetIssuesByQuery(string projectKey, string issueType, string jqlQuery)
        {
            var issues = jira.GetIssuesByQuery(projectKey, issueType , jqlQuery);
            return issues;
        }
        public IEnumerable<Transition> GetTransitions(Issue<IssueFields> issue)
        {
            var transitions = jira.GetTransitions(issue);
            return transitions;
        }

        
        
    }

    public interface IJiraService
    {
        IEnumerable<Issue<IssueFields>> GetIssues();

        IEnumerable<Status> GetStatuses();

        IEnumerable<Transition> GetTransitions(Issue<IssueFields> issue);

        IEnumerable<Issue<IssueFields>> GetIssuesByQuery(string projectKey, string issueType, string jqlQuery);

        Issue<IssueFields> CreateIssue(string codigoBarra);

        Issue<IssueFields> TransitionIssue(Issue<IssueFields> issue, Transition transition);

        Issue<IssueFields> GetIssue(string codigoBarra);

        Issue<IssueFields> UpdateIssue(Issue<IssueFields> issue);

    }
}
