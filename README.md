# DockerPlayground

## Architecture

![image](https://user-images.githubusercontent.com/17797666/168889831-5bd0fddc-f676-49ea-9202-2b259e322a39.png)


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

Expexted output:

CLI:

![image](https://user-images.githubusercontent.com/17797666/168890296-0c94c2c9-099e-44b4-9b8f-76d13602f845.png)

To see the list of containers in CLI: `docker ps`

Docker desktop:
![image](https://user-images.githubusercontent.com/17797666/169589340-ac2bf802-9f36-4e3d-a0fc-f490be3f6ae3.png)

Links:

CatalogApi: http://localhost:8091/swagger/index.html

UsersApi: http://localhost:8092/swagger/index.html

OrdersApi: http://localhost:8093/swagger/index.html

Rabbitmq server: http://localhost:15672/

MongoDb: http://localhost:27017/

Mssql: `Data Source=localhost,1433; Initial Catalog=orders; Persist Security Info=True;User ID=SA;Password=Qwerty123456!@#`

Run integration tests:
`docker-compose -f docker-compose.tests.yml up integration-tests`

![image](https://user-images.githubusercontent.com/17797666/169589060-772942f9-9623-4973-8f62-a2a1bbdd3f5d.png)


### 2. Visual studio 

Run needed projects via Project ot Docker profiles:
![image](https://user-images.githubusercontent.com/17797666/163598559-127dceef-28c0-400b-9bf9-f848c676ddae.png)


### 3. Docker CLI/Desktop

Pull rabbitmq and mondodb images if needed:

`docker pull rabbitmq:3-management`

`docker pull mongo`

<b>Build</b> image of needed service(s) `docker build -t {name} -f {path} .`

`docker build -t catalog-api -f Catalog.Api/Dockerfile .`

`docker build -t users-api -f Users.Api/Dockerfile .`

`docker build -t orders-api -f Orders.Api/Dockerfile .`

`docker build -t users-worker -f Users.Worker/Dockerfile .`

https://docs.docker.com/engine/reference/commandline/build/

Also images can be stored in DockerHub

To push images:

```
docker login
docker build -t {account_name}/{image_name} -f {path} .
docker push {account_name}/{image_name}
```

![image](https://user-images.githubusercontent.com/17797666/164201582-27e8bf26-1637-4bf3-92ef-b7e7525bcaa3.png)

Images can be pulled via Docker desktop or CLI

`docker pull {account_name}/{image_name}`

![image](https://user-images.githubusercontent.com/17797666/164201947-f2fd77f2-e063-437b-a7c8-cb99725c24c2.png)

<b>Run</b> images:

CLI:

Create new network if needed:

`docker network create playground-network`

Run image `docker run -p {port if applicable} --name {container_name if applicaple} --network {network_name} {image_name}`

If rabbitmq and mondodb are not installed locally then:

`docker run --rm -it -p 15672:15672 -p 5672:5672 --network playground-network rabbitmq:3-management`

`docker run -p 27017:27017 --network playground-network mongo`

Playground services:

`docker run -p 8091:80 --network playground-network catalog-api`

`docker run -p 8092:80 --network playground-network users-api`

`docker run -p 8093:80 --network playground-network orders-api`

`docker run users-worker`

https://docs.docker.com/engine/reference/commandline/run/

Docker desktop:

![image](https://user-images.githubusercontent.com/17797666/163601955-626febd1-5c76-4bbe-8394-45593d6e4208.png)

![image](https://user-images.githubusercontent.com/17797666/163603244-796e594e-def2-4f4e-9231-6414b6ada162.png)

Services should be available via links:

CatalogApi: http://localhost:8091/swagger/index.html

UsersApi: http://localhost:8092/swagger/index.html

OrdersApi: http://localhost:8093/swagger/index.html

More information:

https://docs.docker.com/samples/dotnetcore/

https://docs.microsoft.com/en-us/dotnet/core/docker/introduction

https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-6.0

https://docs.microsoft.com/en-us/visualstudio/containers/overview?view=vs-2022

https://docs.microsoft.com/en-us/visualstudio/containers/container-tools?view=vs-2022
