@echo off
set REPORTPORTAL_API_TOKEN=%1
set REPORTPORTAL_LAUNCH_NAME=%2
set TEST_OVERTIME_DURATION_SECONDS=%3

set REPORTPORTAL_API_URL="https://reportportal.retailrocket.ru/api/v1"


for /f "tokens=*" %%a in ('curl -X GET "%REPORTPORTAL_API_URL%/frontend/launch?filter.eq.name=%REPORTPORTAL_LAUNCH_NAME%&access_token=%REPORTPORTAL_API_TOKEN%&page.sort=startTime,desc&page.size=1" ^| jq  -c ".[\"content\"] | .[] | .id"') do set LAUNCH_ID=%%a

echo LAUNCHID=%LAUNCH_ID%
echo https://reportportal.retailrocket.ru/ui/#frontend/launches/all/%LAUNCH_ID%
echo LONG TESTS (over %TEST_OVERTIME_DURATION_SECONDS% seconds):
curl -X GET "%REPORTPORTAL_API_URL%/frontend/item?filter.eq.hasChildren=false&filter.eq.launchId=%LAUNCH_ID%&isLatest=false&launchesLimit=0&page.size=10000&access_token=%REPORTPORTAL_API_TOKEN%&page.sort=startTime,desc&page.size=1&filter.gt.duration=%TEST_OVERTIME_DURATION_SECONDS%" | jq -c " .[\"content\"] | .[] | {\"name\": .name, "durationSec": ((.endTime - .startTime)/1000)  }"
