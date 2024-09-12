Remove-Item .\bin -Recurse -Force -Confirm:$false 
Remove-Item .\obj -Recurse -Force -Confirm:$false

dotnet restore .\ConsolePlayground.csproj

dotnet build .\ConsolePlayground.csproj -c Release

dotnet publish .\ConsolePlayground.csproj -c Release -o ./publish

docker build -t playground  .

docker run playground -it --rm