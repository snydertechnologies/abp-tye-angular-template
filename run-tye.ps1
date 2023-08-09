<# Check development certificates #>

if (! (  Test-Path ".\etc\dev-cert\localhost.pfx" -PathType Leaf ) ){
   Write-Information "Creating dev certificates..."
   cd ".\etc\dev-cert"
   .\create-certificate.ps1
   cd..
   cd ..  
}

<# Check Docker containers #>
docker network create snyder-apps-network

<# Add Required services infrastructure information here #>
$requiredServices = @()
	
foreach ($requiredService in $requiredServices) {	

    $nameParam = -join("name=", $requiredService)
	$serviceRunningStatus = docker ps --filter $nameParam
	$isDockerImageUp = $serviceRunningStatus -split " " -contains $requiredService
	
	if( $isDockerImageUp )
	{
		Write-Host ($requiredService + " [up]")
	}
	else
	{
	    cd "./etc/docker/"
		<# Execute any docker-compose override here #>
		cd ../..
		break;
	}
}

<# Run all services #>

tye run --watch