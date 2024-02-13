# Sales Order Web Application
 <h4>This is a Asp.Net Web App that features Order function.</h4>
<div style="display: inline-block;">
    <img alt="C#" src="https://img.shields.io/badge/C%23-blue?style=for-the-badge&logo=C%23">
    <img alt="ASP.NET" src="https://img.shields.io/badge/Asp.Net-purple?style=for-the-badge&logo=.net">
    <img alt="Dapper" src="https://img.shields.io/badge/Dapper-green?style=for-the-badge">
</div>
 <h5>Functions</h5>
 <ul>
  <li>Select</li>
  <li>Update</li>
  <li>Delete</li>
  <li>Create</li>
 </ul>

 <p>So this is a web application developed using Asp.Net, Dapper. Using Dapper we managed to communicate with Sql Server and execute sql commands. While we used Model-View-Controller way to develop a web application, where each controller do a different action, like insert controller contains action method that help us insert data from web app to sql.</p>


<h5>These are some features we incorporated in this application</h5>
<h5>Features</h5>
 <ul>
  <li>Login and logout: CookieAuthentication</li>
  <li>Cache: OutputCache and ResponseCache</li>
  <li>View Validation Attributes like: Required, string length, range()</li>
  <li>Route Attribute</li>
  <li>Bootstrap for CSS</li>
  <li>Mobile Responsive</li>
  <li>Logging: Using Serilog</li>
 </ul>

# Working
<h3>Login Page</h3>

![image](https://github.com/RamaSubramanianT/SalesOrder/assets/109201625/f0bd2d87-55e2-4310-817b-4f87ebf07227)

<hr>
<h3>Index Page</h3>
<p>This page shows all the items present in Orders Table</p>

![image](https://github.com/RamaSubramanianT/SalesOrder/assets/109201625/d6bdff77-61b8-4fff-a1b2-93a6afb18967)


<hr>
<h3>Update Page</h3>

![image](https://github.com/RamaSubramanianT/SalesOrder/assets/109201625/fbdf12f2-06dd-4b6a-8e7b-a59074c41380)



<hr>
<h3>Delete Page</h3>

![image](https://github.com/RamaSubramanianT/SalesOrder/assets/109201625/67959ebd-26c1-47bf-9330-2a924ae1da5e)


<hr>
<h3>Insert Page</h3>

![image](https://github.com/RamaSubramanianT/SalesOrder/assets/109201625/1d3e5c9b-3e64-4595-941f-a70c0ac2c7e9)


<hr>
<h3>Attribute Validation</h3>

![image](https://github.com/RamaSubramanianT/SalesOrder/assets/109201625/0370b7f5-d74a-42d0-b5f9-8c7443dc5dfb) ![image](https://github.com/RamaSubramanianT/SalesOrder/assets/109201625/7d2e4459-fada-4431-9e86-571ab4103970) 

<p>All the fields are validated, no empty value can be passed in any of the input field. Minimum and maximum length are set in product id field, in orderid value greater than 100 is invalid. Password is set to be 8 alphanumeric long and many more validation are done. Error messages will be displayed below the input field if any condition is violated. If a value is not present in Sql database then <b>"No Record Found"</b> is shown.</p>
<hr>

<h3>Log</h3>

![image](https://github.com/RamaSubramanianT/SalesOrder/assets/109201625/be4982e9-f757-45a5-a5b6-5feb4a1ea6c2)

<p>Using Serilog, every Event, Error and Exception is recorded in console and saved in log file.</p>



# Working Process
<p>We use Asp.Net MVC Web App to develop this application, here controller contains action methods which is called when client(web browser) sends a request to server, in response the server will send the contents, this content are mainly webpages which is present in Views and process the logic in the action method.</p>



©️ SalesOrder 2024
