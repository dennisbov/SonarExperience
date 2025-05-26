<?php	
	$dbConnect = mysqli_connect('localhost', 'root', 'root', 'scoreboard');
	
	if(mysqli_connect_errno())
	{
		echo "1: Connection failed";
		exit();
	}
	
	$nickname = $_POST["nickname"];
	$survivalTime = $_POST["survivalTime"];
	$collectedBatteries = $_POST["collectedBatteries"];
	
	$namecheckquery = "SELECT nickname FROM boardofscore WHERE nickname='" . $nickname . "';";
	
	$nameCheck = mysqli_query ($dbConnect, $namecheckquery) or die("2: nameCheck query failed");
	
	if(mysqli_num_rows($nameCheck) > 0)
	{
		$checkTimeQuerry = "SELECT survival_time FROM boardofscore WHERE nickname = '" . $nickname . "';";
		$checkTime = mysqli_query ($dbConnect, $checkTimeQuerry);
		$time = intval(mysqli_fetch_array($checkTime)[0]);
		if($time < $survivalTime)
		{
			$updateTimeQuerry = "UPDATE boardofscore SET survival_time = '" . $survivalTime . "' WHERE nickname = '" . $nickname . "';";
			mysqli_query($dbConnect, $updateTimeQuerry);
		}
		
		$checkScoreQuerry = "SELECT collected_batteries FROM boardofscore WHERE nickname = '" . $nickname . "';";
		$checkScore = mysqli_query ($dbConnect, $checkScoreQuerry);
		$score = intval(mysqli_fetch_array($checkScore)[0]);
		if($score < $collectedBatteries)
		{
			$updateScoreQuerry = "UPDATE boardofscore SET collected_batteries = '" . $collectedBatteries . "' WHERE nickname = '" . $nickname . "';";
			mysqli_query($dbConnect, $updateScoreQuerry);
		}
		echo ("0");
		
		exit();
	}
	
	$lastId = mysqli_query($dbConnect, "SELECT MAX(id) FROM boardofscore;") or die("5: cannot select id");
	$lastIdInteger = intval(mysqli_fetch_array($lastId)[0]);
	
	$insertNicknameQuery = "INSERT INTO boardofscore (id, nickname, survival_time, collected_batteries) 
	VALUES ('" . $lastIdInteger+1 . "', '" . $nickname . "', '" . $survivalTime . "', '" . $collectedBatteries . "');";
	$insertNickname = mysqli_query($dbConnect, $insertNicknameQuery) or die("4: cannot insert new nickname" . $insertNicknameQuery);
	
	
	echo("0");
?>