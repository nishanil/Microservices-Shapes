### Run on Minikube

https://kubernetes.io/docs/tutorials/hello-minikube/

If you're running windows, `Run powershell on admin mode`.

Under k8s folder, deploy services 

`kubectl apply -f .\deployServices.yaml`

After deployment, wait for pods to be created. Then run this command:

`minikube service shapesapigateway` 

This will give you the publicly exposed IP and port for the gateway.

Copy that and replace `CirclesUrl` and `SquaresUrl` in the `deployWebsite.yaml`

Now, deploy the website

` kubectl apply -f .\deployWebsite.yaml`

Run 

`minikube service shapesweb` this should set you up for the demo. 

![](https://github.com/nishanil/Microservices-Shapes/raw/27bbecb81477cf737736de5591f03a635f2623cc/k8s/minikube.png)
