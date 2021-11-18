
<?php
	$inData = getRequestInfo();
	
	$id = $inData["id"];
	$name = $inData["name"];
	$description = $inData["description"];
    $isUnlocked = $inData["isUnlocked"];
    $price = $inData["price"];
    $count = $inData["count"];

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing");
	if ($conn->connect_error) 
	{
		returnWithError( $conn->connect_error );
	} 
	else
	{
		$stmt = $conn->prepare("INSERT into Items (id,name,description,isUnlocked,price,count) VALUES(?,?,?,?,?,?)");
		$stmt->bind_param("ssssss", $id,$name,$description,$isUnlocked,$price,$count);
		$r = $stmt->execute();
        if($r){
            returnWithInfo("Items has been added");
        }else{
            returnWithError("Failed to add itmes");
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
