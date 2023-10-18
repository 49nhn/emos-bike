#!/bin/bash

if [[ ! -d certs ]]
then
    mkdir certs
    cd certs/
    if [[ ! -f localhost.pfx ]]
    then
        dotnet dev-certs https -v -ep localhost.pfx -p 7d90b8ca-aab2-48fd-80f5-d3c70463f023 -t
    fi
    cd ../
fi

docker-compose up -d
