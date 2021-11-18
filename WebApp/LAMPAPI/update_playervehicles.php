
<?php
	$inData = getRequestInfo();
	
    $vehicleName= $inData["vehicleName"];
    $isUnlocked = $inData["isUnlocked"];
    $vehicle_id = $inData["vehicle_id"];
    $player_id = $inData["player_id"];

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing");
	if ($conn->connect_error) 
	{
		returnWithError( $conn->connect_error );
	} 
	else
	{
		$stmt = $conn->prepare("UPDATE PlayerVehicle SET isUnlocked=? WHERE vehicleName=?");

		$stmt->bind_param("ss",$isUnlocked,$vehicleName);
		$r = $stmt->execute();                        
        if($r){
            returnWithInfo("Player vehicles Updated");
        }else{
            returnWithError("Failed to update player vehicles");
        }
        
		$stmt->close();
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
	
	function returnWithError( $err )
	{
		$retValue = '{"error":"' . $err . '"}';
		sendResultInfoAsJson( $retValue );
	}
    
    function returnWithInfo( $info)
	{
		$retValue = '{"success":"' . $info . '"}';
		sendResultInfoAsJson( $retValue );
	}
	
?>
