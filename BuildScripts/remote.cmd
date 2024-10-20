@ECHO OFF
setlocal EnableDelayedExpansion

set argsCount=0
for %%a in (%*) do (
    set /A argsCount+=1
    set args[!argsCount!]=%%a
)

set COMMAND=!args[1]!
set CI_USER=!args[2]!
set CI_PASSWORD=!args[3]!

for /l %%x in (4, 1, %argsCount%) do (
    echo EXECUTE %1 ON !args[%%x]!
    call "C:\Program Files\IIS\Microsoft Web Deploy V3\msdeploy.exe" -dest:auto,ComputerName="https://!args[%%x]!.int.retailrocket.ru:8172/msdeploy.axd",UserName=%CI_USER%,Password=%CI_PASSWORD%,AuthType=Basic -verb:sync -source:runCommand=%COMMAND%,waitInterval=20000  -allowUntrusted
    echo !errorlevel!
    if !errorlevel! NEQ 0 (
       echo Failure Reason Given is !errorlevel!
       exit /b !errorlevel!
    )
)
