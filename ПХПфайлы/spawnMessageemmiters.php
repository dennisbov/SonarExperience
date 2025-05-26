<?php	
	$dbConnect = mysqli_connect('localhost', 'root', 'root', 'scoreboard');
	
	if(mysqli_connect_errno())
	{
		echo "1: Connection failed";
		exit();
	}
	$leaderBoardQuerry = "SELECT * FROM messageemmiter;";
	
	$scoreboard = mysqli_query($dbConnect, $leaderBoardQuerry);
	
	if($scoreboard){
		while($row = mysqli_fetch_assoc($scoreboard)){
			echo $row["id"] . "\t" . $row["sender_name"] . "\t" . $row["message"] . "\t" . $row["X"] . "\t" . $row["Y"] . "\n";
		}
	}else{
		echo "messageemmiter is empty!";
	}
	
?>