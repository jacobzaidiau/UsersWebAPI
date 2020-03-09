## About

This is a user management software designed to add users to the system, who may be part of several groups. These groups (i.e. Administrator) have specific permissions allocated to them which allow user with certain privileges to perform tasks.

## Design Choices

I used buttons to navigate throughout the project which is similar to how the software I currently use at work navigates through pages. I noticed in screenshots from the Support section that Core Dental uses the left side of the screen for navigation, which I think would've been a more user friendly method of navigating around the page.

I also noticed that there is an additional entity in Core Practice's database through the support which related directly to this technical test - Permissions.

Essentially, like Users and Groups have a Many to Many relationship, Groups and Permissions also have a many to many relationship.

For the password hashing, I decided to go with Argon2, because it has a positive reputation among cryptographers and won the Password Hashing Contest in 2015.

## Instructions for how to develop, use, and test the code.

Download the project, build and run it in Visual Studio 2019.
