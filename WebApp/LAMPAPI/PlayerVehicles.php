
<?php
	$inData = getRequestInfo();
	
    $vehicle_id = $inData["vehicle_id"];
    $vehicleName = $inData["vehicleName"];
    $isUnlocked = $inData["isUnlocked"];
    $player_id = $inData["player_id"];

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing");
	if ($conn->connect_error) 
	{
		returnWithError( $conn->connect_error );
	} 
	else
	{
		$stmt = $conn->prepare("insert into PlayerVehicle(vehicleName,isUnlocked,player_id) values ('bike',1,(select max(player_id) from Players)),('scooter',0,(select max(player_id) from Players)),('car',0,(select max(player_id) from Players));");

		$r = $stmt->execute();                        
        if($r){
            returnWithInfo("Location has been added");
        }else{
            returnWithError("Failed to add location. Primary/foreign key may have a duplicate entry");
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
