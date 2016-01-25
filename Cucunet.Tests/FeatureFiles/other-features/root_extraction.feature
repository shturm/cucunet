Feature: Root extraction
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the root extraction of a number

	Scenario: General rooting
		Given I have entered 25 into the calculator
		When I press Root Extract
		Then the result should be 5