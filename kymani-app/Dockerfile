FROM nginx:1.25.1-alpine3.17

RUN apk add --no-cache tini

RUN rm -rf /usr/share/nginx/html/*

COPY . /usr/share/nginx/html

EXPOSE 80

ENTRYPOINT ["/sbin/tini", "--"] 

CMD ["nginx", "-g", "daemon off;"]