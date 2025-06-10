$ProjectName = "BlazorApp.ComponentsIntro"
mkdir $ProjectName
set-location $ProjectName
dotnet new sln -n $ProjectName
mkdir src
set-location src
dotnet new blazor -n $ProjectName --interactivity Server
set-location ..
dotnet sln add src/$ProjectName
