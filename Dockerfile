FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Tüm dosyalarý kopyala
COPY . .

# Projeyi derle (Publish et)
# Not: AIScoutProject klasörünün isminin doðruluðundan emin ol
RUN dotnet publish "AIScoutProject/AIScoutProject.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# DLL adýnýn doðruluðundan emin ol
ENTRYPOINT ["dotnet", "AIScoutProject.dll"]