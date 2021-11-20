#!/bin/bash

rm -rf AlinSpace.Arguments/bin/Release/*
dotnet build -c Release
dotnet nuget push AlinSpace.Arguments/bin/Release/AlinSpace.Arguments.*.nupkg --source github --skip-duplicate