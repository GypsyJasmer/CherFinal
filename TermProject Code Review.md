# Code Review Form

|                                                      | ---------------------------------------      |
| ---------------------------------------------------- | -------------------------------------------- |
| Course  number, lab number and lab group             | CS 296                                       |
| Developer                                            | Sandi Jasmer                                 |
| URL  for the project repository and branch on GitHub | https://github.com/GypsyJasmer/CherFinal.git |
| URL  on a server (if it has been published)          |                                              |
| Reviewer  and Date                                   | Sandi Jasmer 3/17/21                         |

###  Instructions

The reviewer will complete this form for the beta version of a lab assignment done by one of their lab partners. After filling out the “Beta” column and adding comments, the reviewer will submit this document to the Code Review assignment on the LMS.

The developer will revise the beta version of their lab work and fill out the “Production” column to reflect any changes they have made. The developer will submit this completed form along with the production version of their lab assignment.

### Review

Add explanatory comments in the row following any "no" answers.

| **Criteria**                                                 | **Beta** | **Release** |
| ------------------------------------------------------------ | -------- | ----------- |
| Does it compile and run without errors?                      |          | Yes         |
|                                                              |          |             |
| Do all the pages load correctly?                             |          | Yes         |
| All pages load however my Fashion > Favorites Page does not load the images to pick your favorite outfit. |          |             |
| Does the style conform to MVC conventions and our class standards? |          | Yes         |
|                                                              |          |             |
| Do all the links, buttons or other UI elements work correctly? |          | Yes         |
|                                                              |          |             |
| Do the design and implementation conform to OOP best practices? |          | Yes         |
| I did testing on the quiz, and zap on a zap branch.          |          |             |
| Does the style conform to C# coding conventions?             |          | Yes         |
|                                                              |          |             |
| Does the solution meet all the requirements?                 |          | No          |
| I am short one working Domain Model.                         |          |             |
|                                                              |          |             |
|                                                              |          |             |

Comments:

*My last Domain Models are tied to favorite outfit. Ch 9 in our book has an example of picking your favorite NFL team and they have three Domain Models tied to it, team, conference and division. I just have two one for oufits with the images and the other outfit year which was to take the place of conference. I had to add sessions and cookies and enable in startup too. One thing that I did differently to work with my project was seeding the data. It was suggested to add OnModelCreating to the context. This wasn't working since I seed my data different I was getting errors about it until I put into my seed data and removed from context. The data shows up in my database though just not populating on the view Favorite under Fashion controller. 

*Zap branch is not merged because it messes with my DB however I ran and have the report included in the branch. https://github.com/GypsyJasmer/CherFinal.git 

*

 

## Appendix

### Aspects of coding style to check

- Is proper indentation used?
- Are the HTML elements and variables named descriptively?
- Have any unnecessary lines of code or files been removed?
- Are there explanatory comments in the code?
- Do variable names use camelCase? 
- Are properties, methods and classes named using PascalCase (aka TitleCase)?
- Are constant names written using ALL_CAPS?



### Best practices in Object Oriented Programming

- Is the code DRY (no duplicated blocks of code)?
- Are named constants used instead of repeated literal constants?
- Is code that does computation or logical operations separated into its own class instead of being added to the code-behind?
- Are all instance variables private?
- Are local variables used instead of instance variables wherever possible?
- Does each method do just one thing (no “Swiss Armey” methods)?
- Are classes “loosely coupled” and “highly coherent”?

 

------

Written by Brian Bird, Lane Community College, winter 2017, updated winter 2020

------

