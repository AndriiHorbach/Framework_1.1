Feature: Warranty


@mytag
Scenario: Mandatory fields for goods return request
	Given I am logged in as user in personal cabinet
	| Login                      | Password |
	| gorbach.andrey.i@gmail.com | 7442d203 |
	When I submit Return request form without mandatory fields
	Then Return request form is not submitted
	#Then I see following messages
	#| ReasonOfReturnMessage            | IssueDetailsMessage                     | TypeOfReturnMessage            | TypeOfDeliveryMessage            |
	#| Причина возврата cannot be blank | Описание неисправности cannot be blank. | Цель возврата cannot be blank. | Способ отправки cannot be blank. |
	