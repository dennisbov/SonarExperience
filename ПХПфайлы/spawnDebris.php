<?php	
	$dbConnect = mysqli_connect('localhost', 'root', 'root', 'scoreboard');
	
	if(mysqli_connect_errno())
	{
		echo "1: Connection failed";
		exit();
	}
	$leaderBoardQuerry = "SELECT * FROM boatdebris;";
	
	$scoreboard = mysqli_query($dbConnect, $leaderBoardQuerry);
	
	if($scoreboard){
		while($row = mysqli_fetch_assoc($scoreboard)){
			echo $row["ownerName"] . "\t" . $row["collectedBattaries"] . "\t" . $row["lastMessage"] . "\t" . $row["X"] . "\t" . $row["Y"] . "\n";
		}
	}else{
		echo "boatdebris is empty!";
	}
	
?>