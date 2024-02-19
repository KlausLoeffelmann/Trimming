
:: Disable Signature checking for Preview Versions (non-signatured) of .NET Libraries

@echo off
setlocal enabledelayedexpansion

:: Find all Visual Studio 2022 installations and store them in a temporary file
"%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe" -prerelease -version "[17.0,18.0)" -property installationPath > vs_installations.txt

:: Initialize counter
set /a count=0

:: Display each installation and increment the counter
echo Available Visual Studio 2022 Installations:
for /F "tokens=*" %%i in (vs_installations.txt) do (
    set /a count+=1
    echo !count!. %%i
    set "path!count!=%%i"
)

:: Check if any installations were found
if %count%==0 (
    echo No Visual Studio 2022 installations found.
    goto end
)

:: Prompt the user to choose an installation
echo.
echo Select an installation (1-%count%):
set /p selection="Enter your choice: "

:: Validate the user input
set /a selectionNum=!selection!
:: Validate the user input
if !selection! LSS 1 (
    echo Invalid choice.
    goto end
)

if !selection! GTR %count% (
    echo Invalid choice.
    goto end
)
:: Ask the user whether to apply changes to the actual installation or the experimental hive
echo.
echo Do you want to disable signature validation for the actual installation or the experimental hive?
echo Enter 1 for actual installation, 2 for experimental hive:
set /p hiveChoice="Enter your choice: "

:: Validate the user input for hive choice
if "!hiveChoice!" neq "1" if "!hiveChoice!" neq "2" (
    echo Invalid choice.
    goto end
)

:: Determine the hive suffix
set "hiveSuffix="
if "!hiveChoice!"=="2" set "hiveSuffix=Exp"

:: Construct the VsRegEdit.exe command
set "vsRegEditCmd="!path%selection%!\Common7\IDE\VsRegEdit.exe" set local %hiveSuffix% HKCU Debugger\EngineSwitches ValidateDotnetDebugLibSignatures dword 0"

:: Execute the VsRegEdit.exe command
echo Running: !vsRegEditCmd!
call !vsRegEditCmd!

:end
endlocal
