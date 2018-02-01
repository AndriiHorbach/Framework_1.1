Feature: Cabinet

Scenario: Personal Cabinet
	Given I am logged in as user in personal cabinet
	| Login              | Password  |
	| rozetka_test@ex.ua | Password1 |
	When I select wishlist
	Then I can create new wishlist

