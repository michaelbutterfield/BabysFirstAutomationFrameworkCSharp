Feature: iOS Calendar Test

@CreateEvent
Scenario: Create a new event

Given I am in the calendar
When I click the new event button
  And I enter the required information
Then the event will be created
