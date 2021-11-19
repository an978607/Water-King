
<?php

	$inData = getRequestInfo();
	
	$id = 0;
	$FirstName = "";
	$LastName = "";
    $points = 0;

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing"); 	
	if( $conn->connect_error )
	{
		returnWithError( $conn->connect_error );
	}
	else
	{
		$stmt = $conn->prepare("SELECT id,FirstName,LastName,points FROM Leaderboard WHERE id=? AND FirstName=? AND LastName =? AND points=?");
		$stmt->bind_param("ssss", $inData["id"], $inData["FirstName"], $inData["LastName"], $inData["points"]);
		$stmt->execute();
		$result = $stmt->get_result();

		if( $row = $result->fetch_assoc()  )
		{
			returnWithInfo( $row['id'], $row['FirstName'], $row['LastName'], $row['points']);
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
		$retValue = '{"id":0,"FirstName":"","LastName":"","points":0,"error":"' . $err . '"}';
		sendResultInfoAsJson( $retValue );
	}
	
	function returnWithInfo($id, $FirstName, $LastName, $points)
	{
		$retValue = '{"id":' . $id . ',"FirstName":"' . $FirstName . '","LastName":"' . $LastName . '","points":' . $points . ',"error":""}';
		sendResultInfoAsJson( $retValue );
	}
	
?>
