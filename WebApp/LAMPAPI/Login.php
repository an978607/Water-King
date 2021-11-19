
<?php

	$inData = getRequestInfo();

	$conn = new mysqli("localhost", "WaterKing", "WaterKing", "WaterKing"); 	
	if( $conn->connect_error )
	{
		returnWithError( $conn->connect_error );
	}
	else
	{
		$sql = " SELECT username,password FROM Users WHERE username='Juleeyahw' and password='Wright10';";
		$result = $conn->query($sql);

		if ($result->num_rows > 0) {
		   //create an array
            $emparray = array();
            while($row =mysqli_fetch_assoc($result))
            {
                $emparray[] = $row;
            }
            echo json_encode($emparray);
		} else {
		  echo "0 results";
		}
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
	
?>

