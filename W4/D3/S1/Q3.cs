Ques 3 index.html=>  <!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tip Calculator</title>
</head>
<body>
   <div class="container" style="background-color: white;">
    <h1>Tip Calculator</h1>
    <form id="tipForm">
        <div class="input-group">
            <label for="billAmount">Bill Amount:</label>
            <input id="billAmount" placeholder="Enter bill amount" required>
        </div>
        <div class="input-group">
            <label for="tipPercentage">Tip Percentage:</label>
            <select id="tipPercentage">
                <option value="5">5%</option>
                <option value="10">10%</option>
                <option value="15">15%</option>
                <option value="20">20%</option>
            </select>
        </div>
        <button style="background-color: #4caf50;;" type="button" onclick="calculateTip()">Calculate Tip</button>
    </form>
    <div id="result">
        <p>Tip Amount: <span id="tipAmount">0</span></p>
        <p>Total Amount: <span id="totalAmount">0</span></p>
   </div>
 
   <script src="script.js"></script>
</body>
</html>
 
 
script.js=>  function calculateTip() {
    const billAmount = parseFloat(document.getElementById('billAmount').value);
    const tipPercentage = parseFloat(document.getElementById('tipPercentage').value);
 
    if (isNaN(billAmount) || billAmount <= 0) {
        alert('Please enter a valid bill amount.');
        return;
    }
 
    const tipAmount = (billAmount * tipPercentage) / 100;
    const totalAmount = billAmount + tipAmount;
 
    document.getElementById('tipAmount').innerText = `${tipAmount.toFixed(2)}`;
    document.getElementById('totalAmount').innerText = `${totalAmount.toFixed(2)}`;
 
}
 
 
