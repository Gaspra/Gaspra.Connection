#Restore paket
dotnet tool restore
dotnet paket restore

#Build projects release
dotnet build ./src/Gaspra.Connection.sln -c Release

#Pack as nuget
dotnet pack ./src/Gaspra.Connection.sln -c Release -o ./.pack