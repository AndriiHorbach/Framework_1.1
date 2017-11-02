Feature: Rozetka

Scenario: Buy Monitor by Dell declarative
	Given I am on the home page	
	When I search for Монитор
	When I filter by Производитель for Dell
	When I proceed to checkout with aaa name, 0999999999 mobile, mail@mail.test e-mail
	Then I can confirm order

Scenario Outline: Buy Monitor by Dell declarative outline
	Given I am on the home page	
	When I search for Монитор
	When I filter by Производитель for Dell
	When I proceed to checkout with <ReceiverName> name, <ReceiverMobile> mobile, <ReceiverEmail> e-mail
	Then I cannot confirm order
Examples: 
	| description | ReceiverName | ReceiverMobile | ReceiverEmail  |
	| first       |              | 0999999999     | mail@mail.test |
	| last        | name         |                | mail@mail.test |


