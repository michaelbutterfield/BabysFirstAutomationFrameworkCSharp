Feature: CardPage

Background: Set up the environment ready for the scenarios to take place
	Given I log in
	When I create the user board
	  And I add "5" cards
	Then the environment will be set up

@AddChecklist
Scenario: Add a checklist to a card
	Given I click on the user created board
	  And I click on a card
	When I add a checklist
	  And I add a checklist item
	Then the checklist will be added
