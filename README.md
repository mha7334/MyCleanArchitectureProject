```
# Define project name and root directory
$slnName = "CleanArchitectureWebApi"
$rootDirectory = "c:\repo"

# Define directories and subdirectories
$slnDirectory = Join-Path $rootDirectory $slnName
$srcDirectory = Join-Path $slnDirectory "src" 
$testsDirectory = Join-Path $slnDirectory "tests"
$domainDirectory = Join-Path $srcDirectory "Domain"
$appDirectory = Join-Path $srcDirectory "Application"
$domainDirectory = Join-Path $srcDirectory "Domain"
$infraDirectory = Join-Path $srcDirectory "Infrastructure"

try {
       
        
    #cleanup exisitng solution directory
    Remove-Item -Path $slnDirectory -Recurse -Force | Out-Null

    # Create directories and subdirectories
    New-Item -ItemType Directory -Path $slnDirectory -Force | Out-Null
    New-Item -ItemType Directory -Path $srcDirectory -Force | Out-Null
    New-Item -ItemType Directory -Path $testsDirectory -Force | Out-Null

    pushd $slnDirectory

    #create new solution
    dotnet new sln

    #create API and other Lib projects
    dotnet new webapi -o src\Api
    dotnet new classlib -o src\Contracts
    dotnet new classlib -o src\Infrastructure
    dotnet new classlib -o src\Application
    dotnet new classlib -o src\Domain

    #add projects to solution
    dotnet sln add (ls src/**/*.csproj)

    #reference projects
    dotnet add .\src\Api\ reference .\src\Application\ .\src\Contracts\
    dotnet add .\src\Infrastructure\ reference .\src\Application\
    dotnet add .\src\Application\ reference .\src\Domain\     

    #add few folders
    New-Item -Force -Path (Join-Path $domainDirectory "Entities") -Name "Dummy.cs" -ItemType "file" -Value "//dummy file"    
    New-Item -Force -Path (Join-Path $domainDirectory "Commons") -Name "Dummy.cs" -ItemType "file" -Value "//dummy file"    
    New-Item -Force -Path (Join-Path $domainDirectory "Exceptions") -Name "Dummy.cs" -ItemType "file" -Value "//dummy file"    
    New-Item -Force -Path (Join-Path $domainDirectory "Enums") -Name "Dummy.cs" -ItemType "file" -Value "//dummy file"    
    New-Item -Force -Path (Join-Path $domainDirectory "Events") -Name "Dummy.cs" -ItemType "file" -Value "//dummy file"    
    New-Item -Force -Path (Join-Path $domainDirectory "ValueObjects") -Name "Dummy.cs" -ItemType "file" -Value "//dummy file"    

    New-Item -Force -Path (Join-Path $appDirectory "Commons") -Name "Dummy.cs" -ItemType "file" -Value "class Test {}"    
    
    New-Item -Force -Path (Join-Path $infraDirectory "Commons") -Name "Dummy.cs" -ItemType "file" -Value "//dummy file"    
    New-Item -Force -Path (Join-Path $infraDirectory "Service") -Name "Dummy.cs" -ItemType "file" -Value "//dummy file"    
    New-Item -Force -Path (Join-Path $infraDirectory "Persistence") -Name "Dummy.cs" -ItemType "file" -Value "//dummy file"    
    


    #create xUnit projects
    dotnet new xunit -o .\tests\Infrastructure.Tests
    dotnet new xunit -o .\tests\Application.Tests
    dotnet new xunit -o .\tests\Domain.Tests

    #add xUnit project to solution
    dotnet sln add (ls tests/**/*.csproj)

    #add references
    dotnet add .\tests\Application.Tests\ reference .\src\Application\
    dotnet add .\tests\Domain.Tests\ reference .\src\Domain\
    dotnet add .\tests\Infrastructure.Tests\ reference .\src\Infrastructure\
    
    popd

    
# Output success message
Write-Host "Clean Architecture C# project structure has been generated successfully."
} catch {
# Output error message
Write-Error "Error: $($Error[0].Exception.Message)"
}
```
