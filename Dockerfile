FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Önce projeyi kopyalayýp restore yapalým (Daha hýzlý build için)
COPY ["AIScoutProject/AIScoutProject.csproj", "AIScoutProject/"]
RUN dotnet restore "AIScoutProject/AIScoutProject.csproj"

# Kalan tüm dosyalarý kopyala
COPY . .
WORKDIR "/src/AIScoutProject"
RUN dotnet build "AIScoutProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AIScoutProject.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
# DLL adýnýn doðruluðundan emin ol (Büyük/Küçük harf duyarlýdýr!)
ENTRYPOINT ["dotnet", "AIScoutProject.dll"]