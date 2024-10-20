@ECHO OFF
setlocal EnableDelayedExpansion

set argsCount=0
for %%a in (%*) do (
    set /A argsCount+=1
    set args[!argsCount!]=%%a
)

set RLZ_PATH=!args[1]!
set PROJECT_NAME=!args[2]!
set VERSION=!args[3]!
set CHANNEL=!args[4]!
set CI_USER=!args[5]!
set CI_PASSWORD=!args[6]!
set POST_COMMAND="%RLZ_PATH%\rlz switch RetailRocket.%PROJECT_NAME% %CHANNEL% %VERSION%"

for /l %%x in (7, 1, %argsCount%) do (
    echo START DEPLOY %PROJECT_NAME% TO !args[%%x]! VERSION=%VERSION% CHANNEL=%CHANNEL% POST_COMMAND=%POST_COMMAND%
    "C:\Program Files\IIS\Microsoft Web Deploy V3\msdeploy.exe" -verbose:warning -verb:sync -source:contentPath=%CD%\_BuildOutput\RetailRocket.%PROJECT_NAME%  -dest:contentPath="%RLZ_PATH%\builds\RetailRocket.%PROJECT_NAME%\%VERSION%",ComputerName="https://!args[%%x]!.int.retailrocket.ru:8172/msdeploy.axd",UserName=%CI_USER%,Password=%CI_PASSWORD%,AuthType=Basic -postSync:runCommand="%RLZ_PATH%\rlz switch RetailRocket.%PROJECT_NAME% %CHANNEL% %VERSION%",waitInterval=20000 -allowUntrusted
)