@Calculator
Feature: Calculator

@AddTwoAndTwo
Scenario: Add two numbers
	Given the calculator is open
	When I enter two plus two
	Then the answer will be 4

@TestScientificCalculator
Scenario: Test the Scientific Calculator
	Given I change the calculator to Scientific
	When I enter log ten
	Then the answer will be 1

@FailureTest
Scenario: Cause Failure
	Given the calculator is open
	When I enter two plus two
	Then the answer will be 3
