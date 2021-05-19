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
	And the list should contain 'Note.txt'
	And the list should not contain 'Note.txt.eumel.metadata.json'
	And the list should contain 'readme.md'
	And the list should not contain 'readme.md.eumel.metadata.json'

@folderStorage
Scenario: Get a list of all document from business layer with parameter
	Given a storage location '.\.SampleStore'
	And a file folder storage service is used
	When a list of documents is requested
	Then the list should contain '2' documents
	And the list should contain '<filename>'
	And the list should not contain '<filename>.eumel.metadata.json'
	And the list id for '<filename>' should be '<id>'
Examples:
| filename  | id                                   |
| Note.txt  | 61951527-3d5f-4443-bd12-786fbf6c35b2 |
| readme.md | 2f68ebc0-220f-43ee-99ac-50a1f6b3d71b |

@folderStorage
Scenario: Get a document from business layer with id
	Given a storage location '.\.SampleStore'
	And a file folder storage service is used
	When a documents with id '<id>' is requested
	Then the name should be '<filename>'
Examples:
| filename  | id                                   |
| Note.txt  | 61951527-3d5f-4443-bd12-786fbf6c35b2 |
| readme.md | 2f68ebc0-220f-43ee-99ac-50a1f6b3d71b |
