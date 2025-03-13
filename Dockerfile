FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app

COPY *.sln .
COPY ClinicScheduler.API/*.csproj ./ClinicScheduler.API/
COPY ClinicScheduler.Application/*.csproj ./ClinicScheduler.Application/
COPY ClinicScheduler.Domain/*.csproj ./ClinicScheduler.Domain/
COPY ClinicScheduler.Infrastructure/*.csproj ./ClinicScheduler.Infrastructure/
COPY ClinicScheduler.Tests/*.csproj ./ClinicScheduler.Tests/
RUN dotnet restore

COPY . .

CMD ["dotnet", "run", "--project", "ClinicScheduler.API"]