# Stage 1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-image
WORKDIR /usr/src/build
COPY . .
RUN dotnet restore
RUN dotnet test ./Tests/Tests.csproj
RUN dotnet publish -c Release -o /publish/

# Stage 2
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
ARG URL_PORT
ENV NUGET_XMLDOC_MODE skip
ENV ASPNETCORE_URLS http://*:${URL_PORT}
WORKDIR /publish
COPY --from=build-image /publish .
ENTRYPOINT ["dotnet", "API.dll"]