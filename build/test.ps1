$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Definition


# comma seprated arguments need to be escaped like
$params = New-Object System.Collections.ArrayList
[void] $params.Add("/p:CollectCoverage=true")
#[void] $params.Add("/p:Exclude='\`"[WebFacade.Core*]*,[WebFacade.Hosting*]*\`"'")
[void] $params.Add("/p:CoverletOutputFormat=lcov /p:CoverletOutput=`"$scriptPath/../test/CoverageReport/lcov.info`"")
[void] $params.Add("/p:ThresholdType='\`"branch,method\`"'")
[void] $params.Add("/p:Threshold=90")

$paramString = $params -join ' '
Invoke-Expression "dotnet test `"$scriptPath/../test/WebFacade.UnitTests`" $paramString"


if ($LASTEXITCODE -ne 0) {
  exit $LASTEXITCODE
}
