<?php

	$inData = getRequestInfo();
	
	$id = 0;
	$name = "";
	$description = "";
	$isUnlocked = 0;

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing"); 	
	if( $conn->connect_error )
	{
		returnWithError( $conn->connect_error );
	}
	else
	{
		$stmt = $conn->prepare("SELECT id,name,description,isUnlocked FROM Items WHERE id=? AND name=? AND description=? AND isUnlocked=?");
		$stmt->bind_param("ssss",$inData["id"], $inData["name"], $inData["description"], $inData["isUnlocked"]);
		$stmt->execute();
		$result = $stmt->get_result();

		if( $row = $result->fetch_assoc()  )
		{
			returnWithInfo($row['id'], $row['name'], $row['description'], $row['isUnlocked'] );
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
		$retValue = '{"id":0,"name":"","description":"", "isUnlocked":0,"error":"' . $err . '"}';
		sendResultInfoAsJson( $retValue );
	}
	
	function returnWithInfo( $id,$name, $description, $isUnlocked)
	{
		$retValue = '{"id":' . $id . ',"name":"' . $name . '","description":"' . $description . '", "isUnlocked":' . $isUnlocked . ',"error":"No errors found"}';
		sendResultInfoAsJson( $retValue );
	}
	
?>

