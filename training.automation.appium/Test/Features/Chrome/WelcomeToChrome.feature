Feature: WelcomeToChrome

Scenario: Accept Welcome to Chrome
	Given I am on the Welcome To Chrome page
	When I click the usage and crash reports textbox
		And I click the Accept & continue button
	Then I will be on the account login page
