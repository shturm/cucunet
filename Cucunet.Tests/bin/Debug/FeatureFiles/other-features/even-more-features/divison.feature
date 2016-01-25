Feature: Divison
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the divison result of two numbers

	Scenario: Divide
		Given I have entered 120 into the calculator
		And I have entered 40 into the calculator
		When I press Divide
		Then the result should be 3

	Scenario: Divide by zero
		Given I have entered 120 into the calculator
		And I have entered 0 into the calculator
		When I press Divide
		Then the result should be Error