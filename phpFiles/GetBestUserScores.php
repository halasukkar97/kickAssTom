<?php
	$db = mysqli_connect('localhost', 'id3374906_rainerschmidt','rainer123') or die('Could not connect: '.mysqli_error($db));
	mysqli_select_db($db, 'id3374906_kickasstomdb') or die('Could not select database');
	
	$Stage = mysqli_real_escape_string($db, $_GET['Stage']);
	$Amount = mysqli_real_escape_string($db, $_GET['Amount']);
	$query = "SELECT Score FROM Scores WHERE Stage = $Stage ORDER BY Score Desc LIMIT $Amount";
	
	$result = mysqli_query($db, $query) or die('query failed: '.mysqli_error($db));
	
	$num_results = mysqli_num_rows($result);
	
	for($i = 0; $i<$num_results; $i++)
	{
		$row = mysqli_fetch_array($result);
		echo $row['Score']."\t";
	}
	?>