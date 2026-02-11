// index.html


<!DOCTYPE html>
<html>
<head>
   <title>Fruit</title>
</head>
<body>
   <h1>Fruit Basket</h1>
   <div id = "input">
     <input id = "fruitInput">
     <button id = "addFruitButton" onclick="AddFruit()">Add Fruit</button>
   </div>

   <div id ="result">
    <p id ="errorMessage" style="color: red;"></p>
   </div>

   <div id ="fruitList">
    <span id ="sp1"></span>
   </div>
   <script src="script.js"></script>
</body>
</html>



  // script.ts


  function AddFruit()
{
    let fruitList: string[] = [];
    let fruit = (<HTMLInputElement>document.getElementById("fruitInput")).value;
    if(fruit.length==0)
    {
        document.getElementById("errorMessage").innerHTML = "Fruit name is required.";
        return;
    }
    fruitList.push(fruit);
    document.getElementById("sp1").innerHTML= "Fruits: "+fruitList.join(',');
}

