FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /App

# Copy the CSPROJ file and restore any dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the project files aND BUILD OUR RELEASE
COPY . ./
RUN dotnet publish -c Release -o out

# generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /App
EXPOSE 80
COPY --from=build-env /App/out .
COPY bin/Release/net5.0/publish/ App/
ENTRYPOINT ["dotnet", "silvan-paul-portfolio-api.dll"]

ENV DOTNET_EnableDiagnostics=0