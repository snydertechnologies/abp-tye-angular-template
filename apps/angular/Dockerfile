FROM node:18-alpine as build

WORKDIR /app
COPY package*.json /app/

RUN npm install
COPY . /app
ARG configuration=production
RUN npm run ng build -- --output-path=dist/angular --configuration $configuration

FROM nginx:alpine

COPY --from=build /app/dist/angular/ /usr/share/nginx/html
