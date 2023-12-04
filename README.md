# RTCContentSystem

[![CodeQL](https://github.com/shashinma/RTCContentSystem/actions/workflows/codeql.yml/badge.svg)](https://github.com/shashinma/RTCContentSystem/actions/workflows/codeql.yml)
[![Lint Code Base](https://github.com/shashinma/RTCContentSystem/actions/workflows/super-linter.yml/badge.svg)](https://github.com/shashinma/RTCContentSystem/actions/workflows/super-linter.yml)
[![OSSAR](https://github.com/shashinma/RTCContentSystem/actions/workflows/ossar.yml/badge.svg)](https://github.com/shashinma/RTCContentSystem/actions/workflows/ossar.yml)
[![LICENSE](https://img.shields.io/github/license/shashinma/RTCContentSystem.svg)](LICENSE)

Содержание
=================
* [Описание](#RTCContentSystem)
* [Состояние сборки](#Состояние-сборки)
* [Развертывание](#Развертывание)


## Состояние сборки
| Branches | .NET | Docker Image  | Docker Packages |
|:--------:|:----:|:-------------:|:---------------:|
|  **master**  | [![Build status](https://github.com/shashinma/RTCContentSystem/actions/workflows/dotnet.yml/badge.svg)](https://github.com/shashinma/RTCContentSystem/actions/workflows/dotnet.yml) [![Dependency Review](https://github.com/shashinma/RTCContentSystem/actions/workflows/dependency-review.yml/badge.svg)](https://github.com/shashinma/RTCContentSystem/actions/workflows/dependency-review.yml) | [![Build status](https://github.com/shashinma/RTCContentSystem/actions/workflows/docker-image.yml/badge.svg)](https://github.com/shashinma/RTCContentSystem/actions/workflows/docker-image.yml) |  [![Build status](https://github.com/shashinma/RTCContentSystem/actions/workflows/docker-publish.yml/badge.svg)](https://github.com/shashinma/RTCContentSystem/actions/workflows/docker-publish.yml) |


### Развертывание
```yml
version: '3.8'
name: rtcservices
services:
  posterminal:
    container_name: rtccontentsystem.posterminal
    image: ghcr.io/shashinma/rtccontentsystem.posterminal:v0.0.5
    build:
      context: POSTerminal
      dockerfile: Dockerfile
    ports:
      - 5000:80
```
