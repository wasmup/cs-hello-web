# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0.302-alpine3.17-amd64 AS build
WORKDIR /app

# Copy the project files and restore dependencies
COPY ./*.csproj ./
RUN dotnet restore

# Copy the remaining files and build the application
COPY . ./
RUN dotnet publish -c Release -o out

# Stage 2: Create a minimal runtime image
FROM mcr.microsoft.com/dotnet/runtime-deps:7.0.302-alpine3.17-amd64 AS runtime
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/out ./

# Expose the desired port(s) for your application
EXPOSE 8080

# Set the entry point for the container
ENTRYPOINT ["./YourApp"]

# Optionally, you can set any environment variables here
# ENV ENV_VARIABLE_NAME value

# Specify any additional runtime configuration, if required
# For example, you can use appsettings.json or other configuration files

