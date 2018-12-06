module Program = 
    
    open Expecto
    open TestFrameworks

    let [<EntryPoint>] main args = 
        runTestsWithArgs defaultConfig args ExpectoTests.tests
