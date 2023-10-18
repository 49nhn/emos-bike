module.exports = {
  apps: [
    {
      name: "AuthServer",
      script: 'pnpm',
      args: "pwsh -c cd ./src/Emos.Bike.AuthServer; dotnet run --no-build",
      autorestart: false
    },
    {
      name: "HttpApi",
      script: 'pnpm',
      args: "pwsh -c cd ./src/Emos.Bike.HttpApi.Host; dotnet run --no-build",
      autorestart: false
    },

  ],
};