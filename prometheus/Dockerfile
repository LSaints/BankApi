FROM prom/prometheus:latest

COPY configs/prometheus.yml /etc/prometheus/

EXPOSE 9090

CMD ["--config.file=/etc/prometheus/prometheus.yml", \
     "--storage.tsdb.path=/prometheus", \
     "--web.console.libraries=/etc/prometheus/console_libraries", \
     "--web.console.templates=/etc/prometheus/consoles"]
