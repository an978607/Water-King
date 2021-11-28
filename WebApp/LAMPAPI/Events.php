
<?php
	$inData = getRequestInfo();
	
	$id = $inData["id"];
	$Name = $inData["Name"];
	$description = $inData["description"];
    $isUnlocked = $inData["isUnlocked"];
    $price = $inData["price"];

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing");
	if ($conn->connect_error) 
	{
		returnWithError( $conn->connect_error );
	} 
	else
	{
		$stmt = $conn->prepare("INSERT into Events (id,Name,description,isUnlocked,price) VALUES(?,?,?,?,?)");
		$stmt->bind_param("sssss", $id,$Name,$description,$isUnlocked,$price);
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
