module Data

    let sanitize x = //None
        if(isNull x) then None else Some x

    let list =  
        let rec f a b = seq { yield a
                              yield! f b (a+b) }
        f 1 1
        |> Seq.cache