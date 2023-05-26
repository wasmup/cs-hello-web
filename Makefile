all:
	dotnet new webapi -o HelloWorld
	cd HelloWorld
	code .
	
	dotnet restore
	dotnet clean
	time dotnet build
# real    0m4.447s
# user    0m2.200s
# sys     0m0.248s

	dotnet clean
	time dotnet build --configuration Release
# real    0m5.386s
# user    0m6.639s
# sys     0m0.666s


	dotnet run --release

	time curl -i http://localhost:8080/

docker:
# https://hub.docker.com/_/microsoft-dotnet-sdk
	docker pull mcr.microsoft.com/dotnet/sdk:7.0