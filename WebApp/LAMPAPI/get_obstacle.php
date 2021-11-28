<?php

	$inData = getRequestInfo();
	
	$id = 0;
	$name = "";
	$hitPoints = 0;

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing"); 	
	if( $conn->connect_error )
	{
		returnWithError( $conn->connect_error );
	}
	else
	{
		$stmt = $conn->prepare("SELECT id,name,hitPoints FROM Obstacles WHERE id=? AND name=? AND hitPoints=?");
		$stmt->bind_param("sss", $inData["id"], $inData["name"], $inData["hitPoints"]);
		$stmt->execute();
		$result = $stmt->get_result();

		if( $row = $result->fetch_assoc()  )
		{
			returnWithInfo($row['id'], $row['name'], $row['hitPoints'] );
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
		$retValue = '{"id":0,"name":"","hitPoints":0,"error":"' . $err . '"}';
		sendResultInfoAsJson( $retValue );
	}
	
	function returnWithInfo( $id,$name, $hitPoints)
	{
		$retValue = '{"id":' . $id . ',"name":"' . $name . '","hitPoints":' . $hitPoints . ', "error":"No errors found"}';
		sendResultInfoAsJson( $retValue );
	}
	
?>

