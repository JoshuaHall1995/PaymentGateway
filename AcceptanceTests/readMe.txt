(What will need to be installed inside of your directory for the AcceptanceTests)

npm init -y
npm install -D cucumber
npm install -D cucumber-pretty
npm install node-fetch
npm install -D hamjest
npm install dotenv
npm install uuid

(Can be ran locally like in pipeline to add the .env file at root level)
cat >> .env << EOF
BASEPATH=http://localhost:7071/api
HOSTKEY=notNeeded
EOF