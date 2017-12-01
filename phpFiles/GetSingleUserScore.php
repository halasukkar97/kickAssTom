<?php
	$db = mysqli_connect('localhost', 'id3374906_rainerschmidt','rainer123') or die('Could not connect: '.mysqli_error($db));
	mysqli_select_db($db, 'id3374906_kickasstomdb') or die('Could not select database');
	
	$UserID = mysqli_real_escape_string($db, $_GET['UserID']);
	$Stage = mysqli_real_escape_string($db, $GET['Stage']);
	$query = "SELECT Score FROM Scores WHERE UserID = $UserID and Stage = $Stage";
	
	$result = mysqli_query($db, $query) or die('query failed: '.mysqli_error($db));
	
	echo mysqli_fetch_array($result)['Score']."\t";
	?>