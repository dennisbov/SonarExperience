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
	$batteriesAmount = $_POST["batteriesAmount"];

	
	$lastId = mysqli_query($dbConnect, "SELECT MAX(id) FROM storage;") or die("5: cannot select id");
	$lastIdInteger = intval(mysqli_fetch_array($lastId)[0]);
	
	$insertNicknameQuery = "INSERT INTO storage (id, batteries_amount, ownerName, X, Y) 
	VALUES ('" . $lastIdInteger+1 . "', '" . $batteriesAmount . "', '" . $nickname . "', '" . $X_coord . "', '" . $Y_coord . "');";
	
	mysqli_query($dbConnect, $insertNicknameQuery);
?>