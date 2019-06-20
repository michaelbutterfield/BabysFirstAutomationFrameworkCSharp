@TrelloApi
Feature: TrelloSearch

@SuccessfulSearch
Scenario: Successful Search
	When I send a search request
	Then I will receive a OK response

@BadSearch
Scenario: Bad Search
	When I send a bad search request
	Then I will receive a BadRequest response

@CreateBoardAuth
Scenario: Create a board
	When I send a create board request
	Then I will receive a OK response

@CreateBoardUnauth
Scenario: Try and create a board without key and/or token
	When I send a create board request with no key or token
	Then I will receive a Unauthorized response