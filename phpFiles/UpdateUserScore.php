<?php
	$db = mysqli_connect('localhost', 'id3374906_rainerschmidt','rainer123') or die('Could not connect: '.mysqli_error($db));
	mysqli_select_db($db, 'id3374906_kickasstomdb') or die('Could not select database');
	
	$UserID = mysqli_real_escape_string($db, $_GET['UserID']);
	$Name = mysqli_real_escape_string($db, $_GET['Name']);
	$PW = mysqli_real_escape_string($db, $_GET['Password']);
	$Stage = mysqli_real_escape_string($db, $_GET['Stage']);
	$Score = mysqli_real_escape_string($db, $_GET['Score']);
	$hash = mysqli_real_escape_string($db, $_GET['hash']);
	$secretKey = "mySecretKey";
	
	$real_hash = md5($Name.$PW.$secretKey);
	
	if($real_hash == $hash)
	{
		$query = "UPDATE Scores SET Score = $Score WHERE UserID = $UserID AND Stage = $Stage;";
		$result = mysqli_query($db, $query) or die('Query fielded; ' .mysqli_error($db));
	}
	else
	{
	    echo $hash."\n";
	    echo $real_hash;
	}
	
	?>