<?php
	$db = mysqli_connect('localhost', 'id3374906_rainerschmidt','rainer123') or die('Could not connect: '.mysqli_error($db));
	mysqli_select_db($db, 'id3374906_kickasstomdb') or die('Could not select database');
	
	$query = "SELECT * FROM 'Users' ORDER BY 'ID' DESC LIMIT 5";
	
	$result = mysqli_query($db, $query) or die('query failed: '.mysqli_error($db));
	
	$num_results = mysqli_num_rows($result);
	
	for($i = 0; $i<$num_results; $i++)
	{
		$row = mysqli_fetch_array($result);
		echo $row['ID']."\t".$row['EmailAddress']."\t".$row['Password']."\n";
	}
	?>