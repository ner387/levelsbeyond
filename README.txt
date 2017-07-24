Coding Assignment

Both the Backend and Front End tasks are done using Visual Studio.

In order to run the projects
1) Open the Notes solution in Visual Studio.
2) In the Solution Explorer to your right, right-click on the "Solution 'Notes'" and click Properties
3) Under Startup Project, select 'Multiple startup projects:'
4) Set the Action of GithubIssues and Notes to Start
5) Click OK.
6) Press Ctrl+F5 or navigate to the Debug menu at the top and click on Start without Debugging to run the application.
7) The front end project should run on http://localhost:51487/GithubIssues
8) The backend project should run on http://localhost:55006
9) If these ports are already in use, you can change them by navigating to the Solution Explorer,
	right click on the project you want to change the port of (GithubIssues/Notes),
	click on Properties, under Web -> Servers -> Project Url, you can change to the specific port you want to use,
	and click on Create Virtual Directory
10) The front end project (GithubIssues) should be pretty straightforward to use.
11) The backend project should also be pretty straightforward to use. The only note I want to make is
	about the quotes surrounding the body of the POST.
	The entire body will be surrounded by double quotes instead of single quotes.
i.e: curl -i -H "Content-Type: application/json" -X POST -d "{'body' : 'Drink the milk!'}" http://localhost:55006/api/notes
12) Everything else works the same as the examples given in the assignment description
i.e: curl -i -H "Content-Type: application/json" -X GET http://localhost:55006/api/notes