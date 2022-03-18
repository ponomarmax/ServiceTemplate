# Build image
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build

# Define Service Name
ARG SERVICE_NAME=ServiceTemplate

WORKDIR /app
COPY ./src ./src
RUN dotnet restore ./src/$SERVICE_NAME/$SERVICE_NAME.csproj


#Publish image
RUN dotnet publish ./src/$SERVICE_NAME/$SERVICE_NAME.csproj -c Release -o ./output

# Runtime image - copy published files into final image 
FROM mcr.microsoft.com/dotnet/aspnet:3.1-alpine

WORKDIR /app
COPY --from=build /app/output .
EXPOSE 6001

ENTRYPOINT ["dotnet", "ServiceTemplate.dll"]
