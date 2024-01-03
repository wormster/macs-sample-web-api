# macs-sample-web-api for Entity Framework
Open the Developer PowerShell from VS, View -> Terminal

cd Macs.WebApi.Endpoints

Enter the following command to add the tools for EF

dotnet tool install -g dotnet-ef

Confirm the version

dotnet ef --version

Enter the following command to create the migration file in the Migrations folder within the Macs.WebApi.DataAccess project.

dotnet ef --startup-project ./ --project ../Macs.WebApi.DataAccess/ migrations add Initial

Enter the following command to create the DB and populate with the initial data

dotnet ef database update --startup-project ./ --project ../Macs.WebApi.DataAccess/
