
<?php
	$inData = getRequestInfo();
	
    $eventName= $inData["eventName"];
    $isUnlocked = $inData["isUnlocked"];
    $id = $inData["id"];
    $player_id = $inData["player_id"];

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing");
	if ($conn->connect_error) 
	{
		returnWithError( $conn->connect_error );
	} 
	else
	{
		$stmt = $conn->prepare("UPDATE PlayerEvents SET isUnlocked=? WHERE eventName=?");

		$stmt->bind_param("ss",$isUnlocked,$eventName);
		$r = $stmt->execute();                        
        if($r){
            returnWithInfo("Player events Updated");
        }else{
            returnWithError("Failed to update player events");
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
