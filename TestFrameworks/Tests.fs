namespace TestFrameworks

module XUnitTests =

    open Xunit
    open Email

    [<Fact>]
    let ``toEmail with null gives info [at] acme [dot] com`` () =
        let name = null
        let expected = "info@acme.com"
        let actual = toEmail name
        Assert.Equal (expected, actual)

module FsUnitTests =

    open Xunit
    open FsUnit.Xunit
    open Email

    [<Fact>]
    let ``toEmail with null gives info [at] acme [dot] com`` () =
        let name = null
        let expected = "info@acme.com"
        let actual = toEmail name
        actual |> should equal expected

module UnquoteTests =

    open Xunit
    open Swensen.Unquote
    open Email

    [<Fact>]
    let ``toEmail with null gives info [at] acme [dot] com`` () =
        let name = null
        let expected = "info@acme.com"
        let actual = toEmail name
        test <@ actual = expected @>

module ExpectoTests =

    open Expecto
    open Email

    [<Tests>]
    let tests =
        test "toEmail with null gives info [at] acme [dot] com" {
            let name = null
            let expected = "info@acme.com"
            let actual = toEmail name
            Expect.equal actual expected "emails did not match"
        }
            