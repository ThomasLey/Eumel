$endpoint = https://localhost:44380/document

$get = Invoke-WebRequest -Uri $endpoint -UseBasicParsing
Write-Information $get

$file = "Add-Document.ps1"
$upload = Invoke-WebRequest -uri "$endpoint/Upload" -Method Post -Infile $file

Write-Information $upload
