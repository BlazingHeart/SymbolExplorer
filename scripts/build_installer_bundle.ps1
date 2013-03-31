#requires -Version 2.0
Param([Parameter(Mandatory=$True)][string]$bundleName)
$PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent
cd $PSScriptRoot

Set-StrictMode -Version 2.0
$ErrorPreference = "Stop"

$wixBin = Resolve-Path "${Env:WIX}\bin"

$candleBin = Resolve-Path "${wixBin}\candle.exe"
$lightBin = Resolve-Path "${wixBin}\light.exe"

cd ..
cd "SymbolExplorer.Installer"

& $candleBin -out "output\product.wixobj" -pedantic "product.wxs" -ext WixUtilExtension

& $lightBin -out "output\${bundleName}.msi" -pedantic "output\product.wixobj" -ext WixUtilExtension

& $candleBin -out "output\bundle.wixobj" -pedantic "bundle.wxs" -ext WixBalExtension

& $lightBin -out "output\${bundleName}.exe" -pedantic "output\bundle.wixobj" -ext WixBalExtension

copy "output\${bundleName}.exe" "..\..\output"