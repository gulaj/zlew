Param ($checkoutdir, $user, $password, $organization, $projectName)

$StarcounterDir = "$checkoutdir\sc"
$StarpackExePath = "$StarcounterDir\starpack.exe"
$FullSourcePath = "$checkoutdir\$projectName\src\$projectName\"

try 
{
	if (Test-Path $StarpackExePath)
	{
		if (-Not (Test-Path Env:\StarcounterBin))
		{ 
			echo "StarcounterBin variable not found, creating..."
			[Environment]::SetEnvironmentVariable("StarcounterBin", "$StarcounterDir", "Process") 
		}
		else { echo "StarcounterBin variable found, proceeding..." }
		
		Push-Location $FullSourcePath
		$createPack = Start-Process -FilePath $StarpackExePath -ArgumentList "-p" -PassThru -Wait -NoNewWindow
		if ($createPack.ExitCode -eq 0)
		{		
			$file = Get-ChildItem -Path "$projectName-*.zip"
			if (!$file) { exit(1) }
			$uploadPack = Start-Process -FilePath $StarpackExePath -ArgumentList "-u $file -o=$organization -u=$user -p=$password" -PassThru -NoNewWindow -Wait
			if ($uploadPack.ExitCode -eq 0)
			{
				exit(0)
			}
			else { exit(1) }
		}
		else { exit(1) }					
	}
	else 
	{ 
		echo "Starpack.exe not found, exiting..." 
		exit(1) 
	}
} 
Catch 
{
	$ErrorMessage = $_.Exception.Message
	Write-Output $ErrorMessage
	exit(1)
}