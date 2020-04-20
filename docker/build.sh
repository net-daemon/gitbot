#!/bin/bash

cd /tmp/bot

echo -e "\033[31mBuilding DaemonBot for platform $TARGETPLATFORM\033[0m" >&2

if [ "$TARGETPLATFORM" == "linux/arm/v7" ]; then
    export RID="linux-arm"
elif [ "$TARGETPLATFORM" == "linux/arm64" ]; then
    export RID="linux-arm"
elif [ "$TARGETPLATFORM" == "linux/amd64" ]; then
    export RID="linux-x64"
else
    echo 'NOT VALID ARCHITECTURE' && exit 1
fi

cd src/bot/
dotnet add package Microsoft.Packaging.Tools.Trimming --version 1.1.0-preview1-26619-01
dotnet publish -c Release -o /bot/bin/publish -r $RID /p:PublishSingleFile=true /p:PublishTrimmed=true /p:TrimUnusedDependencies=true
