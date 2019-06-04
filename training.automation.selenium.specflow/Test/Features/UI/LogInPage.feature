@LogInPage @UI
Feature: LogInPage

Background:
Given I am on the splash page
When I click the log in button


@LogInCorrect
Scenario: Log In with Correct Details
Given I am on the log in page
When I enter the user details
  And I click log in
Then I will be logged in successfully


@LogInInvalidDetails
Scenario Outline: Log In With Invalid Details
Given I am on the log in page
When I enter "<Username>" in the username
	And I enter "<Password>" in the password
Then the error message "<ErrorMessage>" appears
Examples: 
	| Username     | Password     | ErrorMessage     |
	| testusername |              | Invalid password |
	|              | testpassword | There isn't an account for this username    |
	|              |              | Missing email    |

#
#@LogInNoEmail
#Scenario: Log in with no email
#Given I enter the user details
#  But I clear the "Email Address"
#When I click log in
#Then the error "Missing email" will be shown
#
#
#@LogInNoPassword
#Scenario: Log in with no password
#Given I enter the user details
#  But I clear the "Password" 
#When I click log in
#Then the error "Invalid password" will be shown