FROM reapregistry.azurecr.io/dotnet/linux/sdk:8.0 AS build
WORKDIR /src

ARG BUILD_CONFIGURATION=Release
COPY ["teamCityTest/teamCityTest.csproj", "teamCityTest/"]
RUN dotnet restore "teamCityTest/teamCityTest.csproj"
COPY . .
WORKDIR "/src/teamCityTest"
RUN dotnet build "teamCityTest.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "teamCityTest.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM reapregistry.azurecr.io/dotnet/linux/focal/kerberos/8.0/aspnet:1
WORKDIR /app
ENV TZ="Europe/Oslo"
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "teamCityTest.dll"]