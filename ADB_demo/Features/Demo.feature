Feature: Get Scene Command
  In order to inspect the state of a Unity game
  As a programmer
  I want to be able to get the current scene contents

  Background:
    Given I install the app "\fixtures\Redstone_Dev_Android_standalone.apk"
    And I launch it
   # And I load the "demo_title" level

  Scenario: Get game object by name (short form)
    Then I should have a "Main Camera"