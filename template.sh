#!/bin/bash

if [ "$#" -ne 1 ]; then
    echo "Usage: $0 <name>"
    exit 1
fi

name=$1

mkdir $name &&
cp Template/* $name/ &&
mv $name/Template.csproj $name/$name.csproj &&
sed -ri "s/Template/$name/" $name/Program.cs
