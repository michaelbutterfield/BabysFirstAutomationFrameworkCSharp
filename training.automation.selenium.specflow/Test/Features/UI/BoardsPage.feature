﻿Feature: BoardsPage

Background: Set up the environment
Given I log in

Scenario: Create a user test board
Given I am on the boards page
When I click create board
  And I fill in the user board details
Then the user board will be created


Scenario: Delete a user test board
Given I am on the boards page
  And I create the user board
When I click on the user created board
  And go through all the delete prompts
Then the user board will be deleted


Scenario: Delete board
Given I delete all the boards
Then no boards will be left
