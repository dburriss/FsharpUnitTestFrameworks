module Email
    let toEmail name = //"info@acme.com"
        if(isNull name) then "info@acme.com" else sprintf "%s@acme.com" name