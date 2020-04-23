param(
  [string]$ProjectDir,
  [string]$ConfigurationName
)
$RimworldVer="1.1"

if (Test-Path "$ProjectDir\dist\VolcanoVariety" -PathType Container)
{
  Remove-Item -Recurse -Path "$ProjectDir\dist\VolcanoVariety"
}

if ((Test-Path "$ProjectDir\bin\$ConfigurationName\VolcanoVariety.dll" -PathType Leaf))
{
  Copy-Item -Recurse -Path "$ProjectDir\Resources\About" -Destination "$ProjectDir\dist\VolcanoVariety\About"
  Copy-Item -Path "$ProjectDir\LICENSE" -Destination "$ProjectDir\dist\VolcanoVariety"
  New-Item -ItemType Directory -Path "$ProjectDir\dist\VolcanoVariety\$RimworldVer" | Out-Null
  New-Item -ItemType Directory -Path "$ProjectDir\dist\VolcanoVariety\$RimworldVer\Assemblies\" | Out-Null
  Copy-Item -Path "$ProjectDir\bin\Release\VolcanoVariety.dll" -Destination "$ProjectDir\dist\VolcanoVariety\$RimworldVer\Assemblies\"
  Copy-Item -Path "$ProjectDir\Libraries\_harmonycheck.dll" -Destination "$ProjectDir\dist\VolcanoVariety\$RimworldVer\Assemblies\"
  Copy-Item -Path "$ProjectDir\THIRD-PARTY-LICENSES" -Destination "$ProjectDir\dist\VolcanoVariety\$RimworldVer\Assemblies\"
  if (Test-Path "$ProjectDir\1.0" -PathType Container)
  {
    Copy-Item -Recurse -Path "$ProjectDir\1.0\Assemblies" -Destination "$ProjectDir\dist\VolcanoVariety\1.0\"
  }
  [Environment]::Exit(0)
}
else
{
  Write-Host "Cannot build mod distribution directory. $ConfigurationName build not found in bin\$ConfigurationName directory."
  [Environment]::Exit(1)
}