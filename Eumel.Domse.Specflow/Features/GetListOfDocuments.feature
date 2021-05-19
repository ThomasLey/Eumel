Feature: Get a list of documents
	In order to list available documents
	As a user
	I want the system return a list of documents
    --------------------
	The system should be able to return a list of files. The files
	can be filtered using prototype filtering.

@folderStorage
Scenario: Get a list of all document from business layer
	Given a storage location '.\.SampleStore'
	And a file folder storage service is used
	When a list of documents is requested
	Then the list should contain '2' documents

