@SpecificBoardsFeature @UI
Feature: Specific Boards Page

Background: Set up the environment ready for the scenarios to take place
	Given I log in
	When I create the user board
	Then the environment will be set up


@AddingLists
Scenario: Adding several lists
	Given I click on the user created board
	When I create a new list called To Do
	  And I create a new list called Doing
	  And I create a new list called Done
	Then the three boards lists will be created


@AddingCards
Scenario: Adding several cards to a lists
	Given I click on the user created board
	When I create a new list called To Do
	  And I add 5 cards to the new list
	Then the list will contain five cards


@DragAndDropCards
Scenario: Dragging two cards from 'To Do' and 'Done' to 'Doing'
	Given I add "3" lists and "5" cards to each list
	When I click and drag two cards from To Do to Doing
	  And I click and drag two cards from Done to Doing
	Then the cards are moved successfully



@FavouriteBoard
Scenario: Favourite a board
	Given I am on the boards page
	When I click the favourite board star
	Then The board will be favourited