
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
		$stmt = $conn->prepare("insert into Locations(locationName,score,isUnlocked,player_id,description,price) values ('Central Park',0,1,(select max(player_id) from Players),'',0),('Public Library',0,0,(select
max(player_id) from Players),'',0),('Empire State',0,0,(select max(player_id) from Players),'',0), ('High Line',0,0,(select max(player_id) from Players),'',0),('Fifth Avenue',0,0,(select max(player_id) from Players),'',0),('Times Square',0,0,(select max(player_id) from Players),'',0);

");

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
