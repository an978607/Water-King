
<?php
	$inData = getRequestInfo();
	
    $itemName= $inData["itemName"];
    $isUnlocked = $inData["isUnlocked"];
    $id = $inData["id"];
    $player_id = $inData["player_id"];
    $count =$inData["count"];

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing");
	if ($conn->connect_error) 
	{
		returnWithError( $conn->connect_error );
	} 
	else
	{
		$stmt = $conn->prepare("UPDATE PlayerItems SET count=?,isUnlocked=? WHERE itemName=?"); 

		$stmt->bind_param("sss",$count,$isUnlocked,$itemName);
		$r = $stmt->execute();                        
        if($r){
            returnWithInfo("Player items Updated");
        }else{
            returnWithError("Failed to update player items");
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
