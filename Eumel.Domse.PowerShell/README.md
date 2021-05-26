
## Install-Module

Lets find the Eumel PowerShell module

    Find-Module -Name Eumel*

Install amd import eumel domse module

    Install-Module Eumel.Domse.PowerShell
    Import-Module Eumel.Domse.PowerShell -DisableNameChecking


Lets update the module and get the module version

    Update-Module Eumel.Domse.PowerShell
    Get-InstalledModule


## Supported Commands

### Storage Commands

`Test-DomseStore`: Validated if a store configuration is valid

### Document Commands

`Get-DomseDocument`: Returns a list of documents and properties in store

