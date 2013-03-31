#requires –Version 2.0
Param([Parameter(Mandatory=$True)][string]$filePath, [string]$bucketPath = "\")
$PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent

Set-StrictMode –Version 2.0
$ErrorPreference = "Stop"

pushd
cd "${PSScriptRoot}\AWSPowerShell\"
Import-Module "AWSPowerShell.psd1"
popd

Set-DefaultAWSRegion us-east-1

#$root = Resolve-Path "${PSScriptRoot}\.."

#$ProjBinDir = Join-Path $root "SymbolExplorer\bin\Release"

$creds = Get-AWSCredentials "symbolexplorer"

$fileName = (Split-Path $filePath -Leaf)

$bucketKey = (Join-Path $bucketPath $FileName)

echo "Attempting to upload ${filePath} to ${bucketKey}"

Write-S3Object -BucketName "symbolexplorer" -Key $bucketKey -File $filePath -CannedACLName "PublicRead" -Credentials $creds
