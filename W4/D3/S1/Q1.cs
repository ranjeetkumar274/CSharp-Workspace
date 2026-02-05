Javascript Ques1, index.html=>  <!DOCTYPE html>
<html lang="en">
 
<head>
    <title>Fitness Tracker</title>
    <link rel="stylesheet" href="style.css">
</head>
 
<body>
    <div class="container">
        <h1>Fitness Tracker</h1>
        <div class="input-section">
            <input type="text" id="activityDescription" placeholder="Activity Description...">
            <input type="number" id="durationInput" placeholder="Enter duration (minutes)...">
            <button onclick="addActivity()">Add Activity</button>
        </div>
        <table id="activityTable">
            <thead>
                <tr>
                    <th>Activity</th>
                    <th>Duration</th>
                </tr>
            </thead>
            <tbody id="activityTableBody"></tbody>
        </table>
        <div>
            <p id="totalDuration">Total Duration: 0 minutes</p>
        </div>
    </div>
 
    <script src="script.js"></script>
</body>
 
</html>
 
 
 
 
 
 
 
 
script.js=>  let totalDuration=0;
 
function addActivity()
{
    const activityDesc= document.getElementById('activityDescription');
    const durationInput= document.getElementById('durationInput');
    const activityTableBody= document.getElementById('activityTableBody');
    const totalDurationElement= document.getElementById('totalDuration');
 
    if(durationInput.value !== ''&& !isNaN(durationInput.value))
    {
        const activityDuration= parseInt(durationInput.value);
        totalDuration += activityDuration;
 
        const newRow= activityTableBody.insertRow();
        const cellDesc= newRow.insertCell(0);
        const cellDuration= newRow.insertCell(1);
 
        cellDesc.textContent= activityDesc.value || 'No description';
        cellDuration.textContent= `${activityDuration} minutes`;
 
        totalDurationElement.textContent= `Total Duration: ${totalDuration} minutes`;
        durationInput.value='';
        activityDesc.value='';
    }
}
 
