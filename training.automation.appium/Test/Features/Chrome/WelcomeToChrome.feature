Feature: WelcomeToChrome

Scenario: Accept Welcome to Chrome
	Given I am on the Welcome To Chrome page
	When I click the usage and crash reports textbox
		And I click the Accept & continue button
		And I complete the account login page
	Then I will be on the new tab splash page
