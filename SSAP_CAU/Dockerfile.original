FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["SSAP_CAU.csproj", "."]
RUN dotnet restore "SSAP_CAU.csproj"
COPY . .
RUN dotnet build "SSAP_CAU.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SSAP_CAU.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SSAP_CAU.dll"]