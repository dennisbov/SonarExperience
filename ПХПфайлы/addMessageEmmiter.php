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
	$message = $_POST["message"];
	
	$lastId = mysqli_query($dbConnect, "SELECT MAX(id) FROM messageemmiter;") or die("5: cannot select id");
	$lastIdInteger = intval(mysqli_fetch_array($lastId)[0]);
	
	$insertNicknameQuery = "INSERT INTO messageemmiter (id, sender_name, message, X, Y) 
	VALUES ('" . $lastIdInteger+1 . "', '" . $nickname . "', '" . $message . "', '" . $X_coord . "', '" . $Y_coord . "');";
	
	mysqli_query($dbConnect, $insertNicknameQuery);
?>