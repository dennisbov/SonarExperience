<?php
	echo("hi");
	exit();
	$dbConnect = mysqli_connect('localhost', 'root', 'root', 'scoreboard');
	
	if(mysqli_connect_errno())
	{
		echo "1: Connection failed";
		exit();
	}
	
	$nickname = $_POST["nickname"];
	
	$namecheckquery = "SELECT nickname FROM boardofscore WHERE nickname='" . $username . "';";
	
	$nameCheck = mysqli_query ($dbConnect, $namecheckquery) or die("2: nameCheck query failed");
	
	if(mysqli_num_rows($nameCheck) > 0)
	{
		echo "3: Name exists, cannot register";
		exit();
	}
	
	$lastId = mysqli_query($dbConnect, "SELECT MAX(id) FROM boardofscore") or die("5: cannot select id");
	$lastId = $lastId+1;
	
	$insertNicknameQuery = "INSERT INTO boardofscore (id, nickname) VALUES ('" . $lastId+1 . "', '" . $nickname . "');";
	$insertNickname = mysqli_query($dbConnect, &insertNicknameQuery) or die("4: cannot insert new nickname");
	
	echo("0");
?>