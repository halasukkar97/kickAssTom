<?php
	$db = mysqli_connect('localhost', 'id3374906_rainerschmidt','rainer123') or die('Could not connect: '.mysqli_error());
	mysqli_select_db($db, 'id3374906_kickasstomdb') or die('Could not select database');
	
	$Name = mysqli_real_escape_string($db, $_GET['Name']);
	$PW = mysqli_real_escape_string($db, $_GET['Password']);
	$Money = mysqli_real_escape_string($db, $_GET['Money']);
	$LevelProgress = mysqli_real_escape_string($db, $_GET['LevelProgress']);
	$Hearts = mysqli_real_escape_string($db, $_GET['Hearts']);
	$Bombs= mysqli_real_escape_string($db, $_GET['Bombs']);
	$Shields = mysqli_real_escape_string($db, $_GET['Shields']);
	$hash = $_GET['hash'];
	
	$secretKey = "mySecretKey";
	
	$real_hash = md5($Name.$PW.$secretKey);
	
	if($real_hash == $hash)
	{
		$query = "insert into Users values (NULL, '$Name', '$PW', '$Money', '$LevelProgress', '$Hearts', '$Bombs', '$Shields');";
		$result = mysqli_query($db, $query) or die('Query fielded; ' .mysqli_error($db));
	}
	else
	{
	    echo $hash."\n";
	    echo $real_hash;
	}
	
	?>