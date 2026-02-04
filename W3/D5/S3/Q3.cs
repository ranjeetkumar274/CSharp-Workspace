//Details.cshtml

@model Products.Models.Product
<h1>Product Details</h1>
<div>
    <h4>Id: @Model.Id</h4>
     <h4>Name: @Model.Name</h4>
      <h4>Category: @Model.Category</h4>
       <h4>Price: @Model.Price</h4>
        <h4>Stock Quantity: @Model.StockQuantity</h4>
         <h4>Manufacturer: @Model.Manufacturer</h4>

</div>
<a asp-action="Index">Back to List</a>

//Edit.cshtml

@model Products.Models.Product
<form asp-action="Edit">
    <div>
        <label asp-for="Name"></label>
        <input asp-for="Name"/>
        <span asp-validator-for="Name"></span>
    </div>

    <div>
        <label asp-for="Category"></label>
        <input asp-for="Category"/>
        <span asp-validator-for="Name" class="text-danger"></span>
    </div>

    
    <div>
        <label asp-for="Price"></label>
        <input asp-for="Price"/>
        <span asp-validator-for="Name" class="text-danger"></span>
    </div>

     <div>
        <label asp-for="StockQuantity"></label>
        <input asp-for="StockQuantity"/>
        <span asp-validator-for="Name" class="text-danger"></span>
    </div>

    <div>
        <label asp-for="Manufacturer"></label>
        <input asp-for="Manufacturer"/>
        <span asp-validator-for="Name" class="text-danger"></span>
    </div>
   
   <button type="submit" class="btn btn-primary">Save</button>
    

    </form>


     //Index.cshtml

     <h1>Product List</h1>
<table>
    <thead>
        <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Category</th>
            <th>Price</th>
            <th>Stock Quantity</th>
            <th>Manufacturer</th>
            <th>Action</th>
            
        </tr>
    </thead>
    <tbody>
        @foreach(var p in Model)
        {
            <tr>
                <td>@p.Id</td>
                 <td>@p.Name</td>
                  <td>@p.Category</td>
                   <td>@p.Price</td>
                    <td>@p.StockQuantity</td>
                     <td>@p.Manufacturer</td>
                     <td>
                        <a asp-action="Details" asp-route-id="p.Id">Details</a>
                         <a asp-action="Edit" asp-route-id="p.Id">Edit</a>
                          <a asp-action="Delete" asp-route-id="p.Id">Delete</a>
                     </td>
            </tr>
        }
    </tbody>
</table>
