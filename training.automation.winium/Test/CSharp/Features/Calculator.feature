Feature: Calculator

@Calculator
Scenario: Add two numbers
	Given the calculator is open
	When I enter two plus two
	Then the answer will be 4
