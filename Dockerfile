FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Tüm dosyalarý kopyala
COPY . .

# Klasör aramayý býrakýp direkt sistemdeki .csproj dosyasýný bulup publish edelim
RUN dotnet publish *.sln -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# DLL adýnýn doðruluðundan emin ol (Eðer AIScoutProject ise böyle kalmalý)
ENTRYPOINT ["dotnet", "AIScoutProject.dll"]