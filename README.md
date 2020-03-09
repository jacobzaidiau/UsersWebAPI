## About

This is a user management software designed to add users to the system, who may be part of several groups. These groups (i.e. Administrator) have specific permissions allocated to them which allow user with certain privileges to perform tasks.

## Design Choices

The colours #3bd9ba and #f05122 are prevalent on the Core Practice website, and the #3bd9ba color in particular appears to be the colour Core Practice identifies itself with, similar to the purple of Cadbury or the red of Kit Kat. I have used these colours where possible, although the tables are formatted based on what I could see from screenshots in the support section of the core practice website.

I used buttons to navigate throughout the project which is similar to how the software I currently use at work navigates through pages. I noticed in screenshots from the Support section that Core Dental uses the left side of the screen for navigation, which I think would've been a more user friendly method of navigating around the page.

I also noticed that there is an additional entity in Core Practice's database through the support which related directly to this technical test - Permissions.

Essentially, like Users and Groups have a Many to Many relationship, Groups and Permissions also have a many to many relationship.

For the password hashing, I decided to go with Argon2, because it has a positive reputation among cryptographers and won the Password Hashing Contest in 2015.

## Current Bugs

1. The password does not provide accurate feedback to the user as of yet, and does so far too slowly. I will do this by using Angular.js to bind the password data to the password feedback label. Clicking submit without waiting for the feedback results in the application believing there has been no input inserted into the password field at all.

2. The Date Of Birth does not have a calendar tool to help users assign a date of birth in the correct format.

3. I had not added any comments while designing this project. Commenting is an important step in the software development process and I will add them now that I've completed all required tasks.

## Future Plans

I would like to have implemented a Permissions table with a Many to Many relationship to the Groups table.

## Instructions for how to develop, use, and test the code.

Download the project, build and run it in Visual Studio 2019.
