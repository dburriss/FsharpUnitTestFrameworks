namespace TestFrameworks

module XUnitTests =

    open Xunit
    open Email
    open System.Collections.Generic

    [<Fact>]
    let ``sanitize with null gives None`` () =
        let name = null
        let expected = None
        let actual = Data.sanitize name
        Assert.Equal (expected, actual)

    [<Fact>]
    let ``sanitize with empty gives Some`` () =
        let name = ""
        let expected = Some name
        let actual = Data.sanitize name
        Assert.Equal (expected, actual)

    [<Fact>]
    let ``sanitize with bob gives Some bob`` () =
        let name = "bob"
        let expected = Some name
        let actual = Data.sanitize name
        Assert.Equal (expected, actual)

    [<Fact>]
    let ``toEmail with null gives info [at] acme [dot] com`` () =
        let name = null
        let expected = "info@acme.com"
        let actual = toEmail name
        Assert.Equal (expected, actual)

    [<Fact>]
    let ``toEmail with bob gives bob [at] acme [dot] com`` () =
        let name = "bob"
        let expected = "bob@acme.com"
        let actual = toEmail name
        Assert.Equal (expected, actual)

    [<Trait("Category", "Smoke")>]
    [<Fact>]
    let ``get list of numbers`` () =
        let expected = [|1;2;3|]
        let actual = Data.list |> Seq.take 3 |> Seq.toArray
        Assert.Equal<IEnumerable<int>>(expected, actual)

module FsUnitTests =

    open Xunit
    open FsUnit.Xunit
    open Email
    
    [<Fact>]
    let ``sanitize with null gives None`` () =
        let name = null
        let expected = None
        let actual = Data.sanitize name
        actual |> should equal expected

    [<Fact>]
    let ``sanitize with empty gives Some`` () =
        let name = ""
        let expected = Some name
        let actual = Data.sanitize name
        actual |> should equal expected

    [<Fact>]
    let ``sanitize with bob gives Some bob`` () =
        let name = "bob"
        let expected = Some name
        let actual = Data.sanitize name
        actual |> should equal expected

    [<Fact>]
    let ``toEmail with null gives info [at] acme [dot] com`` () =
        let name = null
        let expected = "info@acme.com"
        let actual = toEmail name
        actual |> should equal expected

    [<Fact>]
    let ``toEmail with bob gives bob [at] acme [dot] com`` () =
        let name = "bob"
        let expected = "bob@acme.com"
        let actual = toEmail name
        actual |> should equal expected

    [<Fact>]
    let ``get list of numbers`` () =
        let expected = [|1;2;3|]
        let actual = Data.list |> Seq.take 3 |> Seq.toArray
        actual |> should equal expected

module UnquoteTests =

    open Xunit
    open Swensen.Unquote
    open Email
    
    [<Fact>]
    let ``sanitize with null gives None`` () =
        let name = null
        let expected : string option = None
        let actual = Data.sanitize name
        test <@ actual = expected @>

    [<Fact>]
    let ``sanitize with empty gives Some`` () =
        let name = ""
        let expected = Some name
        let actual = Data.sanitize name
        test <@ actual = expected @>

    [<Fact>]
    let ``sanitize with bob gives Some bob`` () =
        let name = "bob"
        let expected = Some name
        let actual = Data.sanitize name
        test <@ actual = expected @>

    [<Fact>]
    let ``toEmail with null gives info [at] acme [dot] com`` () =
        let name = null
        let expected = "info@acme.com"
        let actual = toEmail name
        test <@ actual = expected @>

    [<Fact>]
    let ``toEmail with bob gives bob [at] acme [dot] com`` () =
        let name = "bob"
        let expected = "bob@acme.com"
        let actual = toEmail name
        test <@ actual = expected @>

    [<Fact>]
    let ``get list of numbers`` () =
        let expected = [|1;2;3|]
        let actual = Data.list |> Seq.take 3 |> Seq.toArray
        test <@ actual = expected @>

module ExpectoTests =

    open Expecto
    open Email

    [<Tests>]
    let datatests = 
        testList "Data tests" [

            test "sanitize with null gives None" {
                let name = null
                let expected = None
                let actual = Data.sanitize name
                Expect.equal actual expected "null should be None"
            }

            test "sanitize with empty gives Some" {
                let name = ""
                let expected = Some name
                let actual = Data.sanitize name
                Expect.equal actual expected "empty string should be Some empty string"
            }
            
            test "sanitize with bob gives Some bob" {
                let name = "bob"
                let expected = Some name
                let actual = Data.sanitize name
                Expect.equal actual expected "bob should be Some bob"
            }

            test "get list of numbers" {
                let expected = [|1;2;3|]
                let actual = Data.list |> Seq.take 3 |> Seq.toArray
                Expect.equal actual expected "lists should equal"
            }
        ]

    [<Tests>]
    let emailtests = 
        testList "Email tests" [
            
            test "toEmail with null gives info [at] acme [dot] com" {
                let name = null
                let expected = "info@acme.com"
                let actual = toEmail name
                Expect.equal actual expected "emails did not match"
            }

            test "toEmail with bob gives bob [at] acme [dot] com" {
                let name = "bob"
                let expected = "bob@acme.com"
                let actual = toEmail name
                Expect.equal actual expected "emails did not match"
            }
        ]
            