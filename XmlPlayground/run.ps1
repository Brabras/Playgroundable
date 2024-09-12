Remove-Item .\bin -Recurse -Force -Confirm:$false 
Remove-Item .\obj -Recurse -Force -Confirm:$false

dotnet restore .\XMLPlayground.csproj

dotnet build .\XMLPlayground.csproj -c Release

dotnet publish .\XMLPlayground.csproj -c Release -o ./publish

docker build -t consoleplayground  .

docker run consoleplayground -it --rm