
<?php
	$inData = getRequestInfo();
	
    $location_id = $inData["location_id"];
    $locationName = $inData["locationName"];
    $score = $inData["score"];
    $isUnlocked = $inData["isUnlocked"];
    $player_id = $inData["player_id"];

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing");
	if ($conn->connect_error) 
	{
		returnWithError( $conn->connect_error );
	} 
	else
	{
		$stmt = $conn->prepare("UPDATE Locations SET score=?, isUnlocked=? WHERE locationName=?");

		$stmt->bind_param("sss",$score,$isUnlocked,$locationName);
		$r = $stmt->execute();                        
        if($r){
            returnWithInfo("Location Updated");
        }else{
            returnWithError("Failed to update location");
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
