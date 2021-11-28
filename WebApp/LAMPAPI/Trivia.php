
<?php
	$inData = getRequestInfo();
	
	$id = $inData["id"];
	$question = $inData["question"];
	$correctAnswer = $inData["correctAnswer"];
    $reward = $inData["reward"];
    $answer1 = $inData["answer1"];
    $answer2 = $inData["answer2"];
    $answer3 = $inData["answer3"];
    $answer4 = $inData["answer4"];

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing");
	if ($conn->connect_error) 
	{
		returnWithError( $conn->connect_error );
	} 
	else
	{
		$stmt = $conn->prepare("INSERT into Trivia (id,question,correctAnswer,reward, answer1, answer2, answer3, answer4) VALUES(?,?,?,?,?,?,?,?)");
		$stmt->bind_param("ssssssss", $id,$question,$correctAnswer,$reward,$answer1, $answer2, $answer3, $answer4); 
        $r = $stmt->execute();
        if($r){
            returnWithInfo("Trivia has been added");
        }else{
            returnWithError("Failed to add");
        }
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
