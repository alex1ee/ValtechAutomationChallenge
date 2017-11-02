Feature: AutomationChallenge


Scenario: Check Latest News Section Displayed
Given I have navigated to the Valtech Homepage
Then the Latest News section is displayed


Scenario Outline: Check Titles Displayed on Pages
Given I have navigated to the Valtech Homepage
When I select the <page> link from the top navigation
Then the H1 tag is displaying <page>

Examples: 
| page     |
| About    |
| Services |
| Work     |

Scenario: Display How Many Valtech offices there are
Given I have navigated to the Valtech Homepage
When I select the Contact Us Icon
Then I will display how many offices there are
