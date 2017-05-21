#!/bin/bash
#../BuildScrips/CopyToComponents.sh "${SolutionDir}/Components" "${TargetDir}"

mkdir -p "$1"

cp -f "$2/"*.* "$1"