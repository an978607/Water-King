
<?php

	$inData = getRequestInfo();
	
	$id = 0;
	$question = "";
	$correctAnswer = 0;
    $reward = 0;
    $answer1 = "";
    $answer2 = "";
    $answer3 = "";
    $answer4 = "";

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing"); 	
	if( $conn->connect_error )
	{
		returnWithError( $conn->connect_error );
	}
	else
	{
		$stmt = $conn->prepare("SELECT id,question,correctAnswer,reward,answer1,answer2,answer3,answer4 FROM Trivia WHERE id=? AND question=? AND correctAnswer=? AND reward=? AND answer1=? AND answer2=? AND answer3=? AND answer4=?");
		$stmt->bind_param("ssssssss", $inData["id"], $inData["question"], $inData["correctAnswer"], $inData["reward"], $inData["answer1"], $inData["answer2"], $inData["answer3"], $inData["answer4"]);
		$stmt->execute();
		$result = $stmt->get_result();

		if( $row = $result->fetch_assoc()  )
		{
			returnWithInfo( $row['id'], $row['question'], $row['correctAnswer'], $row['reward'], $row['answer1'], $row['answer2'], $row['answer3'], $row['answer4']);
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
		$retValue = '{"id":0,"question":"","correctAnswer":0,"reward":0,"answer1":"","answer2":"","answer3":"","answer4":"","error":"' . $err . '"}';
		sendResultInfoAsJson( $retValue );
	}
	
	function returnWithInfo($id, $question, $correctAnswer, $reward)
	{
		$retValue = '{"id":' . $id . ',"question":"' . $question . '","correctAnswer":' . $correctAnswer . ',"reward":' . $reward . ',"answer1":"' . $answer1 . '","answer2":"' . $answer2 . '","answer3":"' . $answer3 . '","answer4":"' . $answer4 . '","error":"No errors found"}';
		sendResultInfoAsJson( $retValue );
	}
	
?>
