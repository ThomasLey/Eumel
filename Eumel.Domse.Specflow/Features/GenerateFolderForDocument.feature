Feature: Folder Structure for Documents
	In order to separate the file according to metadata
	As a user
	I want the system to use a customizable folder structure
    --------------------
	Create a folder structure based on metadata of the file. The folder name depends 
	on the provided metadata and the configured location generator.

@folderStorage
Scenario: Generate folder for id
	Given a guid folder creator
	And a document id of "4f149cc3-fa34-4eac-b7f6-e3b8dfa4314b"
	When the folder name is generated
	Then the result should be "4f149cc3\fa34\4eac\b7f6\e3b8dfa4314b"

@folderStorage
Scenario: Generate folder for filemap field
	Given a tree-based folder creator
	And a metadata "filemap" with value "mail->invoice"
	And with configuration {"Property":"filemap","Separator":"->"}
	When the folder name is generated
	Then the result should be "mail\invoice"
