#!/bin/bash

echo "🚀 Starting deployment..."

# Deploy API
echo ""
echo "📦 Deploying API..."
cd TrouwAPI
func azure functionapp publish trouw-functions-1755253825

# Deploy Website
echo ""
echo "🌐 Deploying Website..."
cd ../TrouwWebsite
dotnet publish -c Release -o bin/Release/net9.0/publish

swa deploy ./bin/Release/net9.0/publish/wwwroot \
  --resource-group rg-trouwwebsite \
  --app-name trouwwebsite-manual \
  --env production

echo ""
echo "✅ Deployment complete!"
echo ""
echo "🔗 API: https://trouw-functions-1755253825.azurewebsites.net"
echo "🔗 Website: https://polite-bay-0cc456b03.1.azurestaticapps.net"