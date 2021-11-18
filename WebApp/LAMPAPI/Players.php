
<?php
	$inData = getRequestInfo();
	
	$player_id = $inData["player_id"];
	$currency = $inData["currency"];
	$fuelAmount = $inData["fuelAmount"];
    $totalScore = $inData["totalScore"];
    $upgrade = $inData["upgrade"];
    $time = $inData["time"];
    $protection = $inData["protection"];
    $selectedVehicle = $inData["selectedVehicle"];

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing");
	if ($conn->connect_error) 
	{
		returnWithError( $conn->connect_error );
	} 
	else
	{
		$stmt = $conn->prepare("INSERT INTO Players (currency,fuelAmount,totalScore,upgrade,time,protection,selectedVehicle) VALUES (?,?,?,?,?,?,?)");

		$stmt->bind_param("sssssss", $currency,$fuelAmount,$totalScore,$upgrade,$time,$protection,$selectedVehicle);
		$stmt->execute();                        
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
