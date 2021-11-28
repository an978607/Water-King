
<?php
	$inData = getRequestInfo();
	
	$id = $inData["id"];
	$name = $inData["name"];
    $isUnlocked = $inData["isUnlocked"];
	$speed = $inData["speed"];
    $description = $inData["description"];
    $price = $inData["price"];

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing");
	if ($conn->connect_error) 
	{
		returnWithError( $conn->connect_error );
	} 
	else
	{
		$stmt = $conn->prepare("INSERT into Vehicles (id,name,isUnlocked,speed,price,description) VALUES(?,?,?,?,?,?)");
		$stmt->bind_param("ssssss", $id,$name,$isUnlocked,$speed,$price,$description);
		$r = $stmt->execute();
        if($r){
            returnWithInfo("Event has been added");
        }else{
            returnWithError("Failed to add");
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
 
    function returnWithInfo( $info)
	{
		$retValue = '{"success":"' . $info . '"}';
		sendResultInfoAsJson( $retValue );
	}
	
	function returnWithError( $err )
	{
		$retValue = '{"error":"' . $err . '"}';
		sendResultInfoAsJson( $retValue );
	}
	
?>
