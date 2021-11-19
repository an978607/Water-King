
<?php
	$inData = getRequestInfo();
	
    $name= $inData["name"];
    $isUnlocked = $inData["isUnlocked"];
    $id = $inData["id"];
    $player_id = $inData["player_id"];
    $count =$inData["count"];
    $price = $inData["price"];

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing");
	if ($conn->connect_error) 
	{
		returnWithError( $conn->connect_error );
	} 
	else
	{
		$stmt = $conn->prepare("UPDATE Items SET price=?,count=?,isUnlocked=? WHERE name=?"); 

		$stmt->bind_param("ssss",$price,$count,$isUnlocked,$name);
		$r = $stmt->execute();                        
        if($r){
            returnWithInfo("items Updated");
        }else{
            returnWithError("Failed to update items");
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
