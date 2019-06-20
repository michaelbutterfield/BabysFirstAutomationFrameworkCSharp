Feature: Calculator

Scenario: Add two numbers
	Given the advanced tab is not open
	When I enter 10
		And I press Plus
		And I enter 5
		And I press equals
	Then the result will be 15
