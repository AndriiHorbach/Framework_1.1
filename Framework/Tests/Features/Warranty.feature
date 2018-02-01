Feature: Warranty


@mytag
Scenario: Return request without orders
	Given I am logged in as user in personal cabinet
	| Login              | Password  |
	| rozetka_test@ex.ua | Password1 |
	When I navigate to Return request  
	Then I see 'Не найдено ни одного заказа, воспользуйтесь поиском по номеру заказа.' message
	