# Set Working Directory
Split-Path $MyInvocation.MyCommand.Path | Push-Location
[Environment]::CurrentDirectory = $PWD

Remove-Item "$env:RELOADEDIIMODS/RyoTune.Reloaded.Serialization.Yaml/*" -Force -Recurse
dotnet publish "./RyoTune.Reloaded.Serialization.Yaml.csproj" -c Release -o "$env:RELOADEDIIMODS/RyoTune.Reloaded.Serialization.Yaml" /p:OutputPath="./bin/Release" /p:ReloadedILLink="true"

# Restore Working Directory
Pop-Location