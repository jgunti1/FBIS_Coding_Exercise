# FBIS_Coding_Exercise
This is the Technical Screen Exercise for Jordan Gunti.
Estimated Hours Spent on This task: 24 hours, This includes any learning that needs to take place and errors that should come up. I am also basing this off an expected work week of 8 hours per day or 3 days for this task. 

Task 1: Archive files
Status: Unable to complete the move of the directories to the Archive folder. Kept getting a path could not be found
error but looked at the path a lot myself. Kept the code in there in comments just to show you what I was trying to do. I think I was trying to do too much but didn't know what scenarios I was missing. Had a lot of checks just in case this directory was missing or if there weren't files for that day.

Task 2: Merge two files and write content to new file.
Status: Able to complete this task. The only problem is that when you try to run it twice there is an error because I wasn't able to archive the files. Ideally, I would have been able to archive the files after I created them so the directory that was created for that day would be in the Archive folder.

Task 3: Create text report of what went on that day.
Status: Able to complete this task. Didn't really run into any problems with this, felt comfortable writing to a file. Trying to keep track of variables was the most difficult part. 

Testing:
I have created directories for the days you could be testing for the week of 03/12/2023. There are no files in the Output folder.
1) Open Program.js
2) Open a Terminal in the Mailing_Task directory
3) Type dotnet run
4) The files will be created in the Output folder
5) Add files to the given day directory with different University IDs and delete files from the output folder

Some assumptions that are made:
The code will only be run once a day.
All the directores already exist.
The names of the directories are already there. 
The format of the admissions and scholarships.
No University ID's will appear twice. 

Hours:
I spent about 4 hours learning c sharp and dot net syntax. Then I spent 6 hours working on archiving files and the merging of files. I spent about 2 hours creating the report files. I spent another 2 hours debugging and testing, trying to get the archive files working. In total = 14 hours. 

Problems I had:
When I was trying to move the the directory for the current day, I kept getting a path doesn't exist error. I was not able to fix this.

There were a couple other path errors when moving the files to output but thats about it.

Highilghts:
I commented things that I thought could be confusing. 
I also left the code in there that I was having trouble with because I think it helps show my process. It is commented out.

Takeaways:
I enjoyed programming in c sharp/dot net 7. There is simplicity about it that was interesting. I usually find the object oriented approach difficult but it wasn't that difficult in c sharp.

To answer the testing questions:
What will happen if a person accidentally runs the Console app before or after the scheduled time?
It would only get the files for that day, the problem would be running it multiple times because the files are not being archived after creating them. It does not matter when the program is run that day.
 What will happen if the Console app wasn’t run previous day, and it runs today?
 The previous day files would not be combined but today's files would be. We would have to change the code to account for the missed day.
