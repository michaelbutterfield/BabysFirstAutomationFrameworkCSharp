﻿@SpecificBoardsFeature
Feature: Specific Boards Page

Background: Set up the environment ready for the scenarios to take place
	Given I am on the splash page
	  And I log in
	  And I am on the boards page
	When I create the user board
	Then the environment will be set up


@AddingLists
Scenario: Clicking on the user board, adding several lists
	Given I click on the user created board
	When I create a new list called To Do
	  And I create a new list called Doing
	  And I create a new list called Done
	Then the three boards lists will be created

@AddingCards
Scenario: Adding several cards to three lists
	Given I click on the user created board
	When I create a new list called To Do
	  And I add five cards to the new list
	  And I create a new list called Doing
	  And I add five cards to the new list
	  And I create a new list called Done
	  And I add five cards to the new list
	Then the three lists will contain five cards each

@DragAndDropCards
Scenario: Dragging two cards from 'To Do' & 'Done' to 'Doing'
	Given I click on the user created board
	When I create a new list called To Do
	  And I add five cards to the new list
	  And I create a new list called Doing
	  And I add five cards to the new list
	  And I create a new list called Done
	  And I add five cards to the new list
	When I click and drag two cards from To Do to Doing
	  And I click and drag two cards from Done to Doing
	Then the 'To Do' cards are in 'Doing'
	  And the 'Done' cards are in 'Doing'

@FavouriteBoard
Scenario: Favourite a board
	Given I am on the boards page
	When I click the favourite board star
	Then The board will be favourited