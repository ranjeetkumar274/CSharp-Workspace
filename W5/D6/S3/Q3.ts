
 
const taskForm = document.getElementById("taskForm") as HTMLInputElement;
const taskInput = document.getElementById("taskInput") as HTMLInputElement;
const taskList = document.getElementById("taskList") as HTMLInputElement;
 
taskForm.addEventListener("submit", function (event) {
    event.preventDefault();
 
    const taskText = taskInput.value.trim();
 
    if (taskText === "") return;
 
    createTask(taskText);
 
    taskInput.value = "";
})
 
function createTask(taskText: string): void {
    const taskDiv = document.createElement("div");
 
    const taskName = document.createElement("p");
 
    taskName.innerText = taskText;
 
    const completeBtn = document.createElement("button");
 
    completeBtn.innerText = "Complete";
 
    const deleteBtn = document.createElement("button");
 
    deleteBtn.innerText = "Delete";
 
    completeBtn.onclick = function () {
        if(completeBtn.innerText == "Complete") {
            taskName.style.textDecoration = "line-through";
 
            completeBtn.innerText = "Undo";
        }
        else {
            taskName.style.textDecoration = "none";
 
            completeBtn.innerText = "Complete";
        }
    }
 
    deleteBtn.onclick = function () {
        taskList.removeChild(taskDiv);
    }
 
    // add elements
    taskDiv.appendChild(taskName);
    taskDiv.appendChild(completeBtn);
    taskDiv.appendChild(deleteBtn);
   
    taskList.appendChild(taskDiv);
}
 
 
 
<!DOCTYPE html>
<html>
 
<head>
    <title>Task Management System</title>
</head>
 
<body>
 
    <h1>Task Management System</h1>
 
    <form id="taskForm">
        <input
            type="text"
            id="taskInput"
            placeholder="Enter a new task"
            required
        >
        <button type="submit">Add Task</button>
    </form>
 
    <div id="taskList"></div>
 
    <script src="script.js"></script>
</body>
 
</html>
 
