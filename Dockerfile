# =============================================
# Stage 1 — Build
# =============================================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy solution and project files first (better layer caching)
COPY TestCiCd.slnx .
COPY TestCiCd/TestCiCd.csproj TestCiCd/
COPY TestCiCd.Tests/TestCiCd.Tests.csproj TestCiCd.Tests/

# Restore dependencies
RUN dotnet restore TestCiCd.slnx

# Copy everything else
COPY . .

# Build and publish
RUN dotnet publish TestCiCd/TestCiCd.csproj \
    --configuration Release \
    --output /app/publish
    #--no-restore \

# =============================================
# Stage 2 — Runtime (smaller final image)
# =============================================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/publish .

# Expose port
EXPOSE 8080

# Run the app
ENTRYPOINT ["dotnet", "TestCiCd.dll"]
