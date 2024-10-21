Remove-Item .\bin -Recurse -Force -Confirm:$false 
Remove-Item .\obj -Recurse -Force -Confirm:$false

dotnet restore .\QRPlayground.csproj

dotnet build .\QRPlayground.csproj -c Release

dotnet publish .\QRPlayground.csproj -c Release -o ./publish

docker build -t playground  .

docker run playground -it --rm