<?php	
	$dbConnect = mysqli_connect('localhost', 'root', 'root', 'scoreboard');
	
	if(mysqli_connect_errno())
	{
		echo "1: Connection failed";
		exit();
	}
	$leaderBoardQuerry = "SELECT * FROM boardofscore ORDER BY collected_batteries DESC;";
	
	$scoreboard = mysqli_query($dbConnect, $leaderBoardQuerry);
	
	if($scoreboard){
		while($row = mysqli_fetch_assoc($scoreboard)){
			echo $row["nickname"] . "\t" . $row["survival_time"] . "\t" . $row["collected_batteries"] . "\n";
		}
	}else{
		echo "Scoreboard is empty!";
	}
	
?>