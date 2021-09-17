# patyclub-server

- clone後執行以下指令以初始化環境

1. 還原專案的相依性和工具
```
dotnet restore
```

2. 安裝dotnet ef工具
```
dotnet tool install --global dotnet-ef
```

3. 初始化資料庫schema
```
dotnet ef database update
```

4. 啟動伺服器
```
dotnet run
```
