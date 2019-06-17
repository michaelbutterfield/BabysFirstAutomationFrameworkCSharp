Feature: YouTube

Background:
Given I navigate to the YouTube website

Scenario Outline: Search Functionality
Given the search button is clickable
When I search '<query>'
Then all of the responses will contain '<query'

Examples:
	| query        |
	| Transformers |
	| Egg          |
	| Beyblade     |
