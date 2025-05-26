<?php	
	$dbConnect = mysqli_connect('localhost', 'root', 'root', 'scoreboard');
	
	if(mysqli_connect_errno())
	{
		echo "1: Connection failed";
		exit();
	}
	$leaderBoardQuerry = "SELECT * FROM storage;";
	
	$scoreboard = mysqli_query($dbConnect, $leaderBoardQuerry);
	
	if($scoreboard){
		while($row = mysqli_fetch_assoc($scoreboard)){
			echo $row["id"] . "\t" . $row["batteries_amount"] . "\t" . $row["ownerName"] . "\t" . $row["X"] . "\t" . $row["Y"] . "\n";
		}
	}else{
		echo "storage is empty!";
	}
	
?>