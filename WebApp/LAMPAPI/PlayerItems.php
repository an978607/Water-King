
<?php
	$inData = getRequestInfo();
	
    $id = $inData["id"];
    $itemName = $inData["itemName"];
    $isUnlocked = $inData["isUnlocked"];
    $player_id = $inData["player_id"];
    $count = $inData["count"];

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing");
	if ($conn->connect_error) 
	{
		returnWithError( $conn->connect_error );
	} 
	else
	{
		$stmt = $conn->prepare("insert into PlayerItems(itemName,description,isUnlocked,player_id,count) values ('test3',' ',1,(select max(player_id) from Players),1),('test2',' ',0,(select max(player_id) from Players),1),('test',' ',0,(select max(player_id) from Players),1);");

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
