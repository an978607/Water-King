
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
    $lastEnergyUpdateTime=$inData["lastEnergyUpdateTime"];


	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing");
	if ($conn->connect_error) 
	{
		returnWithError( $conn->connect_error );
	} 
	else
	{
		$stmt = $conn->prepare("UPDATE Players SET currency=?, fuelAmount=?, totalScore=?, upgrade=?, time=?, protection=?, selectedVehicle=?,lastEnergyUpdateTime=? WHERE player_id = 1");

		$stmt->bind_param("ssssssss", $currency,$fuelAmount,$totalScore,$upgrade,$time,$protection,$selectedVehicle,$lastEnergyUpdateTime);
		$r = $stmt->execute();
        if($r){
            returnWithInfo("Player Updated");
        }else{
            returnWithError("Failed to update");
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
