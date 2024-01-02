# macs-sample-web-api for Entity Framework
Open a Developer PowerShell from VS

cd Macs.WebApi.Endpoints

Enter the following command to create the migration file in the Migrations folder within the Macs.WebApi.DataAccess project.

dotnet ef --startup-project ./ --project ../Macs.WebApi.DataAccess/ migrations add Initial

Enter the following command to create the DB and populate with the initial data

dotnet ef database update --startup-project ./ --project ../Macs.WebApi.DataAccess/
