
<?php
	$inData = getRequestInfo();
	
    $id = $inData["id"];
    $eventName = $inData["eventName"];
    $isUnlocked = $inData["isUnlocked"];
    $player_id = $inData["player_id"];

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing");
	if ($conn->connect_error) 
	{
		returnWithError( $conn->connect_error );
	} 
	else
	{
		$stmt = $conn->prepare("insert into PlayerEvents(eventName,isUnlocked,player_id) values ('Promotion',1,(select max(player_id) from Players)),('Advertisement',0,(select max(player_id) from Players)),('Rival Company Shutdown',0,(select max(player_id) from Players));");

		$r = $stmt->execute();                        
        if($r){
            returnWithInfo("Player items have been added");
        }else{
            returnWithError("Failed to add player items");
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
