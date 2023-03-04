Feature: TestReqRes
	Simple calculator for adding two numbers

	
@GetUserDetails
Scenario Outline: Get the list of users from the api
	Given the user have the api details	
	When the user sends a "<api_method>" request to "<api_name>"
	Then the api should return http status code <status_code>
	And verify that the response contain "<first_name>" and "<last_name>"

	Examples: 
	| api_name    | api_method | status_code | first_name | last_name |
	| ListUsers   | GET        | 200         | Lindsay    | Ferguson  |
	| SingleUsers | GET        | 200         | Janet      | Weaver    |
	
@CreateOrUpdateUserDetails
Scenario Outline: Post the list of users from the api
	Given the user have the api details	
	And the user user sends "<name>" and "<job>" details in the request
	When the user sends a "<api_method>" request to "<api_name>"	
	Then the api should return http status code <status_code>
	And verify that the response contains "<name>" and "<job>"

	Examples: 
	| api_name    | api_method | status_code | name     | job           |
	| CreateUsers | POST       | 201         | morpheus | leader        |
	| UpdateUsers | PUT        | 200         | morpheus | zion resident |
	| UpdateUsers | PATCH      | 200         | morpheus | zion resident |
