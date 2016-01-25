Feature: Subtraction
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the subtraction result of two numbers

	Scenario: General subtraction
		Given I have entered 70 into the calculator
		And I have entered 50 into the calculator
		When I press Subtract
		Then the result should be 20