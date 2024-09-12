Remove-Item .\bin -Recurse -Force -Confirm:$false 
Remove-Item .\obj -Recurse -Force -Confirm:$false

dotnet restore .\Asp.NetPlayground.csproj

dotnet build .\Asp.NetPlayground.csproj -c Release

dotnet publish .\Asp.NetPlayground.csproj -c Release -o ./publish

docker build -t aspnetplayground  .

docker run aspnetplayground -it --rm