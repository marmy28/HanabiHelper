namespace HanabiHelper.Tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

type TesterEnum = A = 0 | B = 4
[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member __.``succ when called with enum should get next one`` () =
        Program.succ TesterEnum.A |> should equal TesterEnum.B