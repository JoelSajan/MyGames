//jshint esversion:6

const express = require("express");
const bodyParser = require("body-parser");
const ejs = require("ejs");
var _ = require('lodash');

const homeStartingContent = "Lacus vel facilisis volutpat est velit egestas dui id ornare. Semper auctor neque vitae tempus quam. Sit amet cursus sit amet dictum sit amet justo. Viverra tellus in hac habitasse. Imperdiet proin fermentum leo vel orci porta. Donec ultrices tincidunt arcu non sodales neque sodales ut. Mattis molestie a iaculis at erat pellentesque adipiscing. Magnis dis parturient montes nascetur ridiculus mus mauris vitae ultricies. Adipiscing elit ut aliquam purus sit amet luctus venenatis lectus. Ultrices vitae auctor eu augue ut lectus arcu bibendum at. Odio euismod lacinia at quis risus sed vulputate odio ut. Cursus mattis molestie a iaculis at erat pellentesque adipiscing.";
const aboutContent = "Hac habitasse platea dictumst vestibulum rhoncus est pellentesque. Dictumst vestibulum rhoncus est pellentesque elit ullamcorper. Non diam phasellus vestibulum lorem sed. Platea dictumst quisque sagittis purus sit. Egestas sed sed risus pretium quam vulputate dignissim suspendisse. Mauris in aliquam sem fringilla. Semper risus in hendrerit gravida rutrum quisque non tellus orci. Amet massa vitae tortor condimentum lacinia quis vel eros. Enim ut tellus elementum sagittis vitae. Mauris ultrices eros in cursus turpis massa tincidunt dui.";
const contactContent = "Scelerisque eleifend donec pretium vulputate sapien. Rhoncus urna neque viverra justo nec ultrices. Arcu dui vivamus arcu felis bibendum. Consectetur adipiscing elit duis tristique. Risus viverra adipiscing at in tellus integer feugiat. Sapien nec sagittis aliquam malesuada bibendum arcu vitae. Consequat interdum varius sit amet mattis. Iaculis nunc sed augue lacus. Interdum posuere lorem ipsum dolor sit amet consectetur adipiscing elit. Pulvinar elementum integer enim neque. Ultrices gravida dictum fusce ut placerat orci nulla. Mauris in aliquam sem fringilla ut morbi tincidunt. Tortor posuere ac ut consequat semper viverra nam libero.";

const app = express();
let days = [];
const content = [];
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
  res.render('home',
  {
    startContent:homeStartingContent,
    posts: days,
  }
);

  // res.sendFile(__dirname+"/index.html");
  // console.log(__dirname+"/index.html");
});

app.get("/contact", function(req,res)
{
  var day = "Weekday";
  var today = new Date();
  var options = {
    weekday : "short",
    day : "numeric",
    month  : "short",
  };
  var day = today.toLocaleDateString("en-US",options);
  res.render('contact', {midContent:contactContent });

  // res.sendFile(__dirname+"/index.html");
  // console.log(__dirname+"/index.html");
});

app.get("/about", function(req,res)
{
  var day = "Weekday";
  var today = new Date();
  var options = {
    weekday : "short",
    day : "numeric",
    month  : "short",
  };
  var day = today.toLocaleDateString("en-US",options);
  res.render('about', {aboutContent:aboutContent });

  // res.sendFile(__dirname+"/index.html");
  // console.log(__dirname+"/index.html");
});

app.get("/compose", function(req,res)
{
  var day = "Weekday";
  var today = new Date();
  var options = {
    weekday : "short",
    day : "numeric",
    month  : "short",
  };
  var day = today.toLocaleDateString("en-US",options);
  res.render('compose', {aboutContent:aboutContent });

  // res.sendFile(__dirname+"/index.html");
  // console.log(__dirname+"/index.html");
});
app.post("/compose", function(req,res)
{

  const day = {
    entryValue:req.body.entryValue,
    textArea:req.body.textArea,
  }
  days.push(day);
  res.redirect('/');

  console.log(days);
});
app.post("/navigate", function(req,res)
{
  console.log("Navigate");
});
app.get("/:name", function(req,res)
{
  var postname = req.params.name;
  console.log(postname);
  days.forEach(function(element)
  {
    if(element.entryValue.toString().toUpperCase()==postname.toString().toUpperCase())
    {
      res.render('post', {postHeading:element.entryValue.toString().toUpperCase(), postContent:element.textArea.toString().toUpperCase()});
    }
  })
});
app.get("/posts/:postname", function(req,res)
{
  var postname = _.lowerCase(req.params.postname.toString());
  res.redirect('/post/'+postname);

});
// app.get("/", function(req,res)
// {
//   res.sendFile(__dirname+"/index.html");
//   console.log(__dirname+"/index.html");
// });

app.listen(3001, function() {
  console.log("Server started on port 3000");
});
