FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build-env
WORKDIR /src
# Copy everything and build
COPY . ./
RUN dotnet restore "todowebapp.ui/todowebapp.ui.csproj"
RUN dotnet publish "todowebapp.ui/todowebapp.ui.csproj" -c Release -o publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as todowebapp
WORKDIR /app
COPY --from=build-env src/publish .
ENTRYPOINT ["dotnet", "todowebapp.ui.dll"]
EXPOSE 80