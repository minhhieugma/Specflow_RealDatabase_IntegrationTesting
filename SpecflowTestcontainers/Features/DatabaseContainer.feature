Feature: Database Container
	I want to load a predefined database everytime I run a test feature.
	The database will auto reset for each feature.

Scenario: I can start a predefined database
	When I execute 'SELECT * FROM dbo.Users'
	Then the result should have '10' records

Scenario: I can select current date
	When I execute 'SELECT GETDATE()'
	Then the result should have '1' records