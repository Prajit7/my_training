const http = require('http');
const fs = require('fs');
const dir = __dirname;
const querystring = require('querystring')
const httpParse = require("url").parse;

function displayPage(res, url) {
    const file = dir + url + ".html";
    fs.createReadStream(file).pipe(res)
}

function errorPage(res) {
    res.writeHead(200, { 'Content-type': 'text/html' });
    res.write("<h1 style='color:red'>OOPS! Something wrong happened</h1>")
    res.write("<hr>")
    res.write("<h2>The Page U have requested is not available with Us!!!")
}




http.createServer((req, res) => {
    if(req.method == "GET"){
        const query = httpParse(req.url).query;
        if(query!=null){
            let obj = httpParse(req.url,true).query;
            const msg = `Thanks ${obj.txtName} for registring with us and your email is ${obj.txtEmail}`;
            res.write(msg);
            res.end();
            return;
        }
    }else if(req.method == "POST"){
        let postedData="";
        req.on("data",function(input){
            postedData+=input;
        })
        req.on("end",function(){
            let post = querystring.parse(postedData);
            const msg = `Thanks ${post['txtName']} for registring and your mail is ${post['txtEmail']}`
            // const msg = `Thanks Mr.${post['txtName']} for registering with Us! UR EMail ${post['txtEmail']} is registered and will be contacted`;
            res.write(msg);
            res.end();
            return;
        })
    }
    switch (req.url) {
        case "/favicon.ico":
            res.end();
            break;

        case "/Register":
            displayPage(res, req.url);
            break;
        case "/Home":
            displayPage(res, req.url);
            break;
        default:
            errorPage(res);
            res.end();
            break;
    }

}).listen(1234);
