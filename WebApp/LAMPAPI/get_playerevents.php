<?php

	$inData = getRequestInfo();
    $player_id = $inData["player_id"];

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing"); 	
	if( $conn->connect_error )
	{
		returnWithError( $conn->connect_error );
	}
	else
	{
		$sql = "select Players.player_id,group_concat(PlayerEvents.eventName) as events,group_concat(PlayerEvents.isUnlocked) as eisUnlocked from Players inner join PlayerEvents on PlayerEvents.player_id = Players.player_id where Players.player_id=".$player_id.";";

		$result = $conn->query($sql);

		if ($result->num_rows > 0) {
		   //create an array
            $emparray = array();
            while($row =mysqli_fetch_assoc($result))
            {
                $emparray[] = $row;
            }
            echo json_encode($emparray[0]);
		} else {
		  echo "0 results";
		}
		$conn->close();
	}
	
	function getRequestInfo()
	{
		return json_decode(file_get_contents('php://input'), true);
	}

	function sendResultInfoAsJson( $obj )
	{
		header('Content-type: application/json');
		echo $obj;
	}
	
?>