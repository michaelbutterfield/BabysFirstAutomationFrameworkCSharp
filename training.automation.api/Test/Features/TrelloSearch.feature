Feature: TrelloSearch

Background:
	Given I retrieve the API credentials

@SuccessfulSearch
Scenario: Successful Search
	When I send a search request
	Then I will recieve a 200 response

@BadSearch
Scenario: Bad Search
	When I send a bad search request
	Then I will recieve a 400 response

@CreateBoardAuth
Scenario: Create a board
	When I send a create board request
	Then I will recieve a 200 response

@CreateBoardUnauth
Scenario: Try and create a board without key and/or token
	When I send a bad create board request
	Then I will recieve a 401 response