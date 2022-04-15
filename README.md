# DockerPlayground

## Architecture

![image](https://user-images.githubusercontent.com/17797666/163599780-d6f75491-d68d-4fa5-9fdd-fe0619f9ea71.png)


## How to start:

### 1. In one step with docker-compose

`docker-compose up [options]` 

Options:
```
-d, --detach               Detached mode: Run containers in the background, print new container names.
--always-recreate-deps     Recreate dependent containers.
--build                    Build images before starting containers.
--force-recreate           Recreate containers even if their configuration
```

more options: https://docs.docker.com/compose/reference/up/

clean prevously created containers:

`docker-compose down`

Links:

CatalogApi: http://localhost:8091/swagger/index.html

UsersApi: http://localhost:8092/swagger/index.html

Rabbitmq server: http://localhost:15672/

MongoDb: http://localhost:27017/

### 2. Visual studio 

If rabbitmq and mondodb don't install locally then execute:

docker run --rm -it -p 15672:15672 -p 5672:5672 rabbitmq:3-management

docker run -p 27017:27017 mongo

After that run needed projects via Project ot Docker profiles:
![image](https://user-images.githubusercontent.com/17797666/163598559-127dceef-28c0-400b-9bf9-f848c676ddae.png)


### 3. Docker CLI/Desktop
 
If rabbitmq and mondodb don't install locally then execute:

`docker run --rm -it -p 15672:15672 -p 5672:5672 rabbitmq:3-management`

`docker run -p 27017:27017 mongo`

<b>Build</b> image of needed service(s) `docker build -t {name} -f {path} .`

`docker build -t catalog-api -f Catalog.Api/Dockerfile .`

`docker build -t users-api -f Users.Api/Dockerfile .`

`docker build -t users-worker -f Users.Worker/Dockerfile .`

https://docs.docker.com/engine/reference/commandline/build/

<b>Run</b> images:

CLI:

`docker run -p 8091:80 -e ASPNETCORE_ENVIRONMENT='Development' catalog-api`

`docker run -p 8092:80 -e ASPNETCORE_ENVIRONMENT='Development' users-api`

`docker run -e ASPNETCORE_ENVIRONMENT='Development' users-worker`

https://docs.docker.com/engine/reference/commandline/run/

Docker desktop:
![image](https://user-images.githubusercontent.com/17797666/163601955-626febd1-5c76-4bbe-8394-45593d6e4208.png)

![image](https://user-images.githubusercontent.com/17797666/163603244-796e594e-def2-4f4e-9231-6414b6ada162.png)

Services should be accessable via links:

CatalogApi: http://localhost:8091/swagger/index.html

UsersApi: http://localhost:8092/swagger/index.html
