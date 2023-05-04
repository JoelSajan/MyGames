const express = require("express");
const bodyParser = require("body-parser");

var day_items = ['games','cooking'];
var work_items = [];

const app = express();
app.set('view engine', 'ejs');
app.use(bodyParser.urlencoded({extended: true}));
app.use(express.static("public"));
app.get("/", function(req,res)
{
  var day = "Weekday";
  var today = new Date();
  var options = {
    weekday : "short",
    day : "numeric",
    month  : "short",
  };
  var day = today.toLocaleDateString("en-US",options);

  res.render('list', {listTitle: day, newListItems: day_items});
  // res.sendFile(__dirname+"/index.html");
  // console.log(__dirname+"/index.html");
});

app.get("/work", function(req,res)
{

  res.render('list', {listTitle: "Work List", newListItems: work_items});
});

app.get("/about", function(req,res)
{
  res.render('about');
});

app.post("/", function(req,res)
{
  if(req.body.button=="Work")
  {
    work_items.push(req.body.newItem);
    res.redirect("/work");
  }
  else
  {
    day_items.push(req.body.newItem);
    res.redirect("/");
  }

});

app.listen(3000, function()
{
  console.log("server started at port 3000");
});
