#requires –Version 3.0
Param([Parameter(Mandatory=$True)][string]$filePath, [string]$bucketPath = "\")

Set-StrictMode –Version 3.0
$ErrorPreference = "Stop"

$root = Resolve-Path "${PSScriptRoot}\.."

$ProjBinDir = Join-Path $root "SymbolExplorer\bin\Release"

$creds = Get-AWSCredentials "symbolexplorer"

$fileName = (Split-Path $filePath -Leaf)

$bucketKey = (Join-Path $bucketPath $FileName)

echo "Attempting to upload ${filePath} to ${bucketKey}"

Set-DefaultAWSRegion us-east-1

Write-S3Object -BucketName "symbolexplorer" -Key $bucketKey -File $filePath -CannedACLName "PublicRead" -Credentials $creds
