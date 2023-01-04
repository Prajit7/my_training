const http = require("http")

http.createServer(function(req,res){
    console.log(req.url)
    if(req.url == "/Employee")
        res.write("Employee Page")
    else if(req.url == "/Customer")
        res.write("Customer Page")
    else res.write("Default page")
        res.end();

}).listen(1234)

