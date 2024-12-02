kubectl create secret generic certificate-secret --from-file=certificate.pfx=F:/PosTechFiap/https-certificate/certificate.pfx

kubectl apply -f Infrastructure\\Kubernets\\Database\\PersistentVolume
kubectl apply -f Infrastructure\\Kubernets\\Database\\PersistentVolumeChain
kubectl apply -f Infrastructure\\Kubernets\\Database
kubectl apply -f Infrastructure\\Kubernets\\Api
kubectl apply -f Infrastructure\\Kubernets\\UpdateContactCommandConsumer
kubectl apply -f Infrastructure\\Kubernets\\DeleteContactCommandConsumer
kubectl apply -f Infrastructure\\Kubernets\\CreateContactCommandConsumer
kubectl apply -f Infrastructure\\Kubernets\\Grafana
kubectl apply -f Infrastructure\\Kubernets\\NodeExporter
kubectl apply -f Infrastructure\\Kubernets\\Prometheus
kubectl apply -f Infrastructure\\Kubernets\\RabbitMQ\\Data\\PersistentVolume
kubectl apply -f Infrastructure\\Kubernets\\RabbitMQ\\Data\\PersistentVolumeChain
kubectl apply -f Infrastructure\\Kubernets\\RabbitMQ\\Logs\\PersistentVolume
kubectl apply -f Infrastructure\\Kubernets\\RabbitMQ\\Logs\\PersistentVolumeChain
kubectl apply -f Infrastructure\\Kubernets\\RabbitMQ