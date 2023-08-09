# SnyderApps (Tye ABP Angular) monorepo

This is a template project based on [eShopOnAbp](https://github.com/abpframework/eShopOnAbp) with minimal configuration
and services, ready to be used as a template to create new, fresh, microservices architectures.

Currently the Tye runner contains the following features:

- **Angular** application;
- Example service as ABP Framework module;
- Example service gateway using YARP;

## How to Run?

You can either run in Visual Studio, or using [Microsoft Tye](https://github.com/dotnet/tye). Tye is a developer tool that makes developing, testing, and deploying micro-services and distributed applications easier.

 ### Requirements

- .NET 7.0+
- Docker
- Yarn

### Instructions

- Clone the repository ( [eShopOnAbp](https://github.com/abpframework/eShopOnAbp) )
- Install Tye (*follow [these steps](https://github.com/dotnet/tye/blob/main/docs/getting_started.md#installing-tye)*)
- Rename `.env.example` file to `.env`.
- Execute `run-tye.ps1`

- Wait until all applications are up!

	- You can check running application from tye dashboard ([localhost:8000](http://127.0.0.1:8000/))
	- **Note**: If you see all of your applications keep restarting on tye dashboard or tye console, you may be facing ssl certificate issues. To diagnose the problems better, check any application logs. If it is related with SSL, developer certificate creation may have failed because of powershell issues regarding authorization. Check the powershell script running configuration and set policy for your local machine as: 
	```bash
	Get-ExecutionPolicy -list
	Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope LocalMachine
	```
	See [Microsoft Powershell documentation](https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.security/get-executionpolicy?view=powershell-7.2) for more information.

- After all your backend services are up, start the angular application:

  ```bash
  cd apps/angular
  yarn start
  ```

### Certificate Expiration
If the cerficiate is expired you'll see following error:

<!-- Make it smaller with 320px height  -->
<img src="docs/images/ssl-error.png" height="320"/>

Generating a new certificate will fix that issue. To generate new one,

- Remove `etc/dev-cert/localhost.pfx`
- Manually execute `create-certificate.ps1` **or** re-run solution with `run-tye.ps1`
