# ServiceTemplate description
It tends to be a basic template for .Net Core service

It constains the following preconfigured things:

- serilog logging
- swagger
- basic dockerfile
- simple Integration-test pattern and Unit-test one
- EF with Sql or InMemory

It uses for demonstration purposes InMemory DB. If you gonna use real DB then remove all lines with comment #DemontrationOnly


##Docker

To build and run use the following commands:

```
docker build -t <image_name> .
docker run -p 6001:6001 <image_name>
```

Example:

```
docker build -t sertemp .
docker run -p 6001:6001 sertemp
```