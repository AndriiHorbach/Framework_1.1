Feature: Warranty


@mytag
Scenario: Mandatory fields for goods return request
	Given I am logged in as user in personal cabinet
	| Login                      | Password |
	| gorbach.andrey.i@gmail.com | 7442d203 |
	When I submit Return request form without mandatory fields
	#Then Return request form is not submitted
	Then I see 'Необходимо заполнить «Причина возврата».', 'Необходимо заполнить «Описание неисправности».', 'Необходимо заполнить «Цель возврата».', 'Необходимо заполнить «Способ отправки».' messages
	