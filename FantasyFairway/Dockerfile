FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["FantasyFairway/FantasyFairway.csproj", "FantasyFairway/"]
RUN dotnet restore "FantasyFairway/FantasyFairway.csproj"
COPY . .
WORKDIR "/src/FantasyFairway"
RUN dotnet build "FantasyFairway.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FantasyFairway.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FantasyFairway.dll"]