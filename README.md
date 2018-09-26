# Microservices-Shapes

Simple demo with two microservices written in.NET Core, accessed via API Gateway (ocelot) from a Webapp.

What you can do with this sample?
 - Build locally using `docker-compose up`
 - Deploy to Kubernetes with just the yaml files inside `k8s` folder

## Architecture

![image](https://user-images.githubusercontent.com/3107766/46022275-ebcbde00-c0ff-11e8-8bbd-07265443b089.png)




## Run Locally

### Prerequisites

- [Install docker](https://www.docker.com/products/docker-desktop) on your system
- Once the installation completes, test your installation by running the following command in the command prompt/powershell/terminal: `docker --version`. You should get an output with a docker version.

To run locally, clone this repository and navigate to `Shapes` folder in your repo in a command prompt/powershell/terminal and run `docker-compose up`

Navigate to `http://localhost:3000` and enjoy! 

If you've, Visual Studio installed, you can directly run the project after opening `Shapes.sln`.


## Run on Azure Kubernetes Service

You can deploy and run to AKS without running it locally! This is a pure magic of Containers. The images have been pushed to my docker hub repository and the `.yaml` files have been updated to pull from it by default. 

To deploy on AKS, make sure you have an Azure Subscription and Azure CLI setup. Following instructions will help you with it.

1. [Download and install Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest)
2. Login to Azure
   Open Command prompt/terminal/powershell and type in this command:
   ```
    az login
   ```
   If the CLI can open your default browser, it will do so and load a sign-in page. Complete the sign-in process.
3. Create a Resource Group
    ```
    az group create --name myaksrg --location westus
    ```
4. Create an AKS Cluster
    ```
    az aks create --resource-group myaksrg --name shapescluster --node-count 1 --enable-addons http_application_routing --generate-ssh-keys
    ```
   Please note: This command will take a while to complete.
5. Install AKS Client CLI
   ```
    az aks install-cli
   ```
6. Get Credentials
    ```
    az aks get-credentials --resource-group myaksrg --name shapescluster
    ```
7. To Deploy, navigate to `k8s` folder in command prompt/powershell/terminal and Run this command:

    ```
    kubectl apply -f deployServices.yaml
    ```
8. Wait for your services to get deployed. A public IP will be assiged to your `ShapesAPIGateway`. You can use this command to watch: `kubectl get services --watch`
   ![image](https://user-images.githubusercontent.com/3107766/46074789-31db7d00-c1a6-11e8-80a4-3fb5ca20ec8d.png)
10. Copy the Public IP that is assiged to your gateway, and replace them in the file `deployWebsite.yaml` in th section:
    ```
       env:
        - name: CirclesUrl
          value: "http://<yourpublicip>"
        - name: SquaresUrl
          value: "http://<yourpublicip>"
    ```
    Save the file.
11. Deploy the website now:
    ```
    kubectl apply -f deployWebsite.yaml
    ```
12. Wait for your website to get deployed. A public IP will be assigned to your website as well. Copy that one, and navigate to it in a browser. That's it!

