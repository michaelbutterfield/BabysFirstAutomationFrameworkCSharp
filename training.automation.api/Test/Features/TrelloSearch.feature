@TrelloApi
Feature: TrelloSearch

@SuccessfulSearch
Scenario: Successful Search
	When I send a search request
	Then I will receive a 200 response

@BadSearch
Scenario: Bad Search
	When I send a bad search request
	Then I will receive a 400 response

@CreateBoardAuth
Scenario: Create a board
	When I send a create board request
	Then I will receive a 200 response

@CreateBoardUnauth
Scenario: Try and create a board without key and/or token
	When I send a create board request with no key or token
	Then I will receive a 401 response