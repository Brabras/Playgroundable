FROM mcr.microsoft.com/dotnet/runtime:8.0

RUN sed -i 's/providers = provider_sect/providers = provider_sect\n\
ssl_conf = ssl_sect\n\
\n\
[ssl_sect]\n\
system_default = system_default_sect\n\
\n\
[system_default_sect]\n\
Options = UnsafeLegacyRenegotiation/' /etc/ssl/openssl.cnf

WORKDIR /app

COPY ./publish /app/

ENTRYPOINT ["dotnet", "ConsolePlayground.dll"]