FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app
COPY ./OneModel/OneModel.csproj ./OneModel/
RUN dotnet restore ./OneModel/OneModel.csproj
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 9050
ENV ASPNETCORE_URLS=http://+:9050
ENTRYPOINT ["dotnet", "OneModel.dll"]
