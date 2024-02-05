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

| Branches | Dependencies | .NET | Docker Image  | Docker Scout | Docker Packages | 
|:--------:|:------------:|:----:|:-------------:|:---------------:|:---------------:|
|  **`master`**  | [![Dependency Review](https://github.com/shashinma/RTCContentSystem/actions/workflows/dependency-review.yml/badge.svg)](https://github.com/shashinma/RTCContentSystem/actions/workflows/dependency-review.yml) | [![Build status](https://github.com/shashinma/RTCContentSystem/actions/workflows/dotnet.yml/badge.svg)](https://github.com/shashinma/RTCContentSystem/actions/workflows/dotnet.yml) | [![Build status](https://github.com/shashinma/RTCContentSystem/actions/workflows/docker-image.yml/badge.svg)](https://github.com/shashinma/RTCContentSystem/actions/workflows/docker-image.yml) | [![Docker Scout](https://github.com/shashinma/RTCContentSystem/actions/workflows/docker-scout.yml/badge.svg?branch=master)](https://github.com/shashinma/RTCContentSystem/actions/workflows/docker-scout.yml) | [![Build status](https://github.com/shashinma/RTCContentSystem/actions/workflows/docker-publish.yml/badge.svg)](https://github.com/shashinma/RTCContentSystem/actions/workflows/docker-publish.yml) |


## Развертывание
> [!IMPORTANT]  
> Создать docker-compose.yml
> ```yml
> version: '3.8'
>
> name: rtccontentsystem
> services:
>  posterminal:
>    container_name: rtccontentsystem.posterminal
>    image: ghcr.io/shashinma/rtccontentsystem.posterminal:latest
>    restart: unless-stopped
>    build:
>      context: POSTerminal
>      dockerfile: Dockerfile
>    ports:
>      - <container_port>:8080
>    environment:
>      ASPNETCORE_ENVIRONMENT: Production
>      ConnectionStrings__IdentityConnection: DataSource=identity.db;Cache=Shared
>      ConnectionStrings__ApplicationDbConnection: DataSource=app.db;Cache=Shared
>      DefaultUserOptions__AdminUser__Username: <admin_username@mail.com>
>      DefaultUserOptions__AdminUser__Password: <admin_password>
>      DefaultUserOptions__TerminalUser__Username: <terminal_usename@mail.com>
>      DefaultUserOptions__TerminalUser__Password: <terminal_password>
> ```

> [!NOTE]
> Для создания сервиса docker-compose используйте:
> ```sh
> docker compose create
> ```
> После успешного создания сервиса запустите сервис командой:
> ```sh
> docker compose up
> ```
