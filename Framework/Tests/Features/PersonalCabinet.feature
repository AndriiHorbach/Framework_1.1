Feature: Cabinet

Scenario: Personal Cabinet
	Given I am logged in as user in personal cabinet
	| Login                      | Password |
	| gorbach.andrey.i@gmail.com | 7442d203 |
	When I select wishlist
	#Then wishlist is empty
	Then I can create new wishlist

