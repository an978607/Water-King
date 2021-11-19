<?php

	$inData = getRequestInfo();
	
	$id = 0;
	$name = "";
	$isUnlocked = 0;
	$speed = 0;
    $description = "";
    $price = 0;
        
	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing"); 	
	if( $conn->connect_error )
	{
		returnWithError( $conn->connect_error );
	}
	else
	{
		$stmt = $conn->prepare("SELECT id,name,isUnlocked,speed, description,price FROM Vehicles WHERE  id=? AND name=? AND isUnlocked=? AND speed=? AND description=? AND price=?");
		$stmt->bind_param("ssssss",$inData["id"], $inData["name"], $inData["isUnlocked"], $inData["speed"],$inData["description"],$inData["price"]);
		$stmt->execute();
		$result = $stmt->get_result();

		if( $row = $result->fetch_assoc()  )
		{
			returnWithInfo($row['id'], $row['name'],$row['isUnlocked'], $row['speed'],$row['description'],$row['price'] );
		}
		else
		{
			returnWithError("No Records Found");
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
		$retValue = '{"id":0,"name":"","isUnlocked":0, "speed":0,"description":"","price":0,"error":"' . $err . '"}';
		sendResultInfoAsJson( $retValue );
	}
	
	function returnWithInfo( $id,$name, $isUnlocked, $speed, $price, $description)
	{
		$retValue = '{"id":' . $id . ',"name":"' . $name . '","isUnlocked":' . $isUnlocked . ', "speed":' . $speed . ',"price":' .$price. ', "decription":"'.description.'", "error":"No errors found"}';
		sendResultInfoAsJson( $retValue );
	}
	
?>

