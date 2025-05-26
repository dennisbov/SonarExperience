<?php	
	$dbConnect = mysqli_connect('localhost', 'root', 'root', 'scoreboard');
	
	if(mysqli_connect_errno())
	{
		echo "1: Connection failed";
		exit();
	}
	
	$X_coord = $_POST["X"];
	$Y_coord = $_POST["Y"];
	$nickname = $_POST["nickname"];
	$collectedBatteries = $_POST["collectedBatteries"];
	$lastMessage = $_POST["lastMessage"];
	
	$namecheckquery = "SELECT ownerName FROM boatdebris WHERE ownerName='" . $nickname . "';";
	
	$nameCheck = mysqli_query ($dbConnect, $namecheckquery) or die("2: nameCheck query failed");
	
	if(mysqli_num_rows($nameCheck) > 0)
	{
		$updateTimeQuerry = "UPDATE boatdebris 
		SET collectedBattaries = '" . $collectedBatteries . "', lastMessage = '" . $lastMessage . "', X = '" . $X_coord . "',
		Y = '" . $Y_coord . "'  
		WHERE ownerName = '" . $nickname . "';";
		mysqli_query($dbConnect, $updateTimeQuerry);
	}
	
	$insertNicknameQuery = "INSERT INTO boatdebris (ownerName, collectedBattaries, lastMessage, X, Y) 
	VALUES ('" . $nickname . "', '" . $collectedBatteries . "', '" . $lastMessage . "', '" . $X_coord . "', '" . $Y_coord . "');";
	
	mysqli_query($dbConnect, $insertNicknameQuery);
?>