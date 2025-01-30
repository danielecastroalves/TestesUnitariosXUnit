# before run this script, you need to install the following dotnet tool
# dotnet tool install -g dotnet-reportgenerator-globaltool

$strFolderName = ".\coveragereport\opencoverage"
If (Test-Path $strFolderName){
	Remove-Item $strFolderName -Recurse -Verbose
}

dotnet test --collect "XPlat Code Coverage" `
--results-directory ".\coveragereport\opencoverage" `
--settings coverlet.runsettings

reportgenerator "-reports:coveragereport/opencoverage/**/coverage.opencover.xml" `
"-targetdir:coveragereport/html" "-reporttypes:Html" "-title:CalculadoraFinanceira"

Start-Process "./coveragereport/html/index.htm"

Read-Host -Prompt "Press Enter to exit"
