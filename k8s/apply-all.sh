#!/bin/bash

# For Unix-like operating systems (Linux Distros, Mac OS ...)
# /> chmod +x apply-all.sh
# Apply all files (including subdirectories)
kubectl apply -f ./k8s/metrics/metrics.yaml
kubectl apply -f ./k8s/techmedicos-namespace.yaml
kubectl apply -f ./k8s/techmedicos-configmap.yaml
kubectl apply -f ./k8s/deployments/techmedicos-api-deployment.yaml