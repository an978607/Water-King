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
		$sql = "select Players.player_id,Players.currency,Players.fuelAmount,Players.selectedVehicle,Players.lastEnergyUpdateTime,Players.upgrade,Players.protection,Players.time,Players.totalScore,group_concat(Locations.score)as score,group_concat(Locations.locationName)as locationName,group_concat(Locations.isUnlocked) as isUnlocked,group_concat(Locations.price) as price from Locations inner join Players on Locations.player_id = Players.player_id where Players.player_id=".$player_id.";";
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