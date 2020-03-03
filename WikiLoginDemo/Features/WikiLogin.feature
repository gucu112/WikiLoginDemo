Feature: WikiLogin
	In order to access Wikipedia features
	As a member of the internet community
	I want to be able to log into Wikipedia

@owner:me @critical @issue:WIK-1 @tms:https://jira.example.org/browse/WIK-1 @positive
Scenario: Log into Wikipedia
	Given The user that exists
	And Wikipedia login page
	When The user enters provided credentials
	And The user clicks login button
	Then The user should be logged in

@owner:me @critical @issue:WIK-1 @tms:https://jira.example.org/browse/WIK-1 @positive
Scenario Outline: Check validation of empty fields
	Given The user that exists
	And Wikipedia login page
	When The user enters "nothing" in "<enterField>" field
	And The user clicks login button
	Then The user should not be logged in
	And Validation message for "<validField>" should appear

	Examples:

		| enterField | validField |
		| password   | username   |
		| username   | password   |

@owner:me @critical @issue:WIK-1 @tms:https://jira.example.org/browse/WIK-1 @negative
Scenario Outline: Try to log into Wikipedia
	Given Wikipedia login page
	When The user enters "<username>" in "username" field
	And The user enters "<password>" in "password" field
	And The user clicks login button
	Then The user should not be logged in
	And Validation message for incorrect credentials should appear

	Examples:
	# @see: https://github.com/minimaxir/big-list-of-naughty-strings/blob/master/blns.txt

		| username | password |
		| abcdef   | alhjfdb  |
		| ąśćźżł   | %$EF4    |
		| _$^*()   | 5467     |
#		| 和製漢語        | 部落格         |
#		| ¯\_(ツ)_/¯   | ( ͡° ͜ʖ ͡°) |
#		| 🐵 🙈 🙉 🙊 | ❤️ 💔 💌 💕 |


#@owner:me @critical @issue:WIK-3 @tms:https://jira.example.org/browse/WIK-3 @positive @negative
#Scenario: Use "I don't remember password" feature

#@owner:me @minor @issue:WIK-2 @tms:https://jira.example.org/browse/WIK-2 @positive @negative
#Scenario: Log into Wikipedia with remember me option