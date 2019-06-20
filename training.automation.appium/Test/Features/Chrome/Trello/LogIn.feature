Feature: LogIn

Background:
Given I am on the splash page
When I click the log in button


@LogInCorrect
Scenario: Log In with Correct Details
Given I am on the log in page
When I put in the user details
  And I click log in
Then I will be logged in successfully

