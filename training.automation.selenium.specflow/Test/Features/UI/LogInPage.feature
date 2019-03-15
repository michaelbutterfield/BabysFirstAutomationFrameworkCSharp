@LogInPage @UI
Feature: LogInPage

Background:
Given I am on the splash page
When I click the log in button


@LogInCorrect
Scenario: Log In with Correct Details
Given I log in
Then I will be logged in successfully


@LogInNoEmail
Scenario: Log in with no email
Given I enter the user details
  But I clear the "Email Address"
Then the error "Missing Email" will be shown


@LogInNoPassword
Scenario: Log in with no password
Given I enter the user details
  But I clear the "Password"
Then the error "Invalid Password" will be shown