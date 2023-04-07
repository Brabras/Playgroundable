FROM mcr.microsoft.com/dotnet/runtime:6.0

WORKDIR /app

RUN apt-get -y update && apt-get -y upgrade 
RUN apt-get install -y ffmpeg

COPY ./bin/Release/net6.0/publish /app/

ENTRYPOINT ["dotnet", "FfmpegPlayground.dll"]
