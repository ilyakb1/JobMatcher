# Requirements

**JobAdder Coding Challenge**

# Solution design
![picture](docs/img/solution_design.gif)

# Page mockup
![picture](docs/img/page_mockup.gif)

# Job to Candidate matching logic
Job SkillTags: Skill 1, Skill 2, Skill 3

Candidate 1 Skills: Skill 2, Skill 1, Skill 5

Candidate 2 Skills: Skill 1, Skill 5, Skill 6

Candidate 2 Skills: Skill 5, Skill 6, Skill 1

Match priority: 
	
	1) Find candidates: Candidate first skill = Job first skill
	
		1.1 Found. 
		
				Find candidates: Candidate first skill = Job second skill
				
			1.1.1 Found
			
					Find candidates: Candidate first skill = Job third skill
					
					...continue
					
					"Return one candidate."
					
		1.2 Not Found:
		
				Find candidates: Candidate second skill = Job second skill
				
				1.2.1 Found: Similar to 1.1.1
				
		... continue
		
		Return "Candidate not found"
		
			
	2) Not found: 
		Find candidates: Candidate second skill = Job first skill

	3) Not found: 
		Continue with Candidate third, forth,... skill
		
	4) Not found 
			Return "Candidate not found"
			

# Setup instruction

# Testing instructions
1) Run WebApi tests 
Go to .\JobMatcher\JobMatcher.Tests folder and run "dotnet test"

2) Run Jasmin tests
Go to .\JobMatcher\src\ClientApp folder and run "npm run test"
	
# Deployment instructions
1) Run solution
Go to .\JobMatcher\src folder and run "dotnet run"
Open page  http://localhost:5000   in browser

# Job Matching Result
![picture](docs/img/jobmatcher-result.gif)

#To Do
1) Add Backend tests to conteroller
2) Group jobbs by company
3) Add front end unit test
4) Add Caching to job matching
5) Do algorithm more eficient for large number jobs, candidates and skills


