Feature: PowerShell Commands for Document Management
	In order to manage the storage with powershell
	As a user
	I want to use powershell commands to create, read, update, delete documents
    --------------------
    Define the powershell commands which are used to manage documents in folder/storage.

@storageManagement
Scenario: Add document to storage
	Given a powershell parameter "File":"Resources\Note.txt"
	And a powershell parameter "Configuration":"file://./.eumelStoreTemp"
	When execute Add-DomseDocument 
	Then the result should return a DocumentInformation
	And the DocumentInformation should contain the document name
