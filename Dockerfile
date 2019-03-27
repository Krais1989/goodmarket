FROM microsoft/dotnet:2.2-sdk AS build_env
WORKDIR /app

# Copy *.sln, all the *.csproj and restore dependencies
COPY *.sln .
# COPY GoodMarket.Common/*.csproj 			./GoodMarket.Common/
# COPY GoodMarket.Domain/*.csproj 			./GoodMarket.Domain/
# COPY GoodMarket.Persistence/*.csproj 		./GoodMarket.Persistence/
# COPY GoodMarket.Application/*.csproj 		./GoodMarket.Application/
# COPY GoodMarket.Api/*.csproj 				./GoodMarket.Api/
# COPY GoodMarket.Application.Tests/*.csproj 	./GoodMarket.Application.Tests/

# Copy sources from projects to specific folders
COPY GoodMarket.Api/. 			./GoodMarket.Api/
COPY GoodMarket.Domain/. 		./GoodMarket.Domain/
COPY GoodMarket.Application/. 	./GoodMarket.Application/
COPY GoodMarket.Persistence/. 	./GoodMarket.Persistence/
COPY GoodMarket.Common/. 		./GoodMarket.Common/
COPY GoodMarket.Application.Tests/. ./GoodMarket.Application.Tests/

RUN dotnet restore
RUN dotnet publish GoodMarket.Api -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
EXPOSE 80
WORKDIR /app
COPY --from=build_env /app/GoodMarket.Api/out .
ENTRYPOINT ["dotnet", "GoodMarket.Api.dll"]

# docker build --network bridge_gm -t goodmarket .
# docker run -d -p 80:80 --name app_api --network bridge_gm --network-alias app1 [IMAGE_ID]
# docker run -rm -p 80:80 --name app_api --network bridge_gm --network-alias app1 [IMAGE_ID]

# docker run -d --name=db_mysql --network bridge_gm --network-alias db1 mysql/mysql-server
# GRANT ALL PRIVILEGES ON *.* TO 'root'@'%' IDENTIFIED BY '123123';