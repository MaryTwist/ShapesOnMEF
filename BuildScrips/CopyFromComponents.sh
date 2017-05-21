#!/bin/bash
#../BuildScrips/CopyFromComponents.sh "${SolutionDir}/Components" "${TargetDir}/Components"

mkdir -p "$1"
mkdir -p "$2"

cp -f "$1/"*.* "$2/"