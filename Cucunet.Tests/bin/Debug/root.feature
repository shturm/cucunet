﻿Feature: Addition
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	Scenario: Add two numbers
		Given I have entered 50 into the calculator
		And I have entered 70 into the calculator
		When I press Add
		Then the result should be 120

	Scenario: Add negative numbers
		Given I have entered 70 into the calculator
		And I have entered -50 into the calculator
		When I press Subtract
		Then the rsult should be 50