namespace CREPDLUnitTest


open NUnit.Framework
open System.IO
open CREPDL
open CREPDL.ReadGraphemeCluster
open System.Xml
open System.Xml.Linq
open System.IO

[<TestFixture>]
module CollectionValidationTest =  
    let createValidator (num: int) = 
        let crepdlScript =  
            @"<repertoire 
            xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0""
            number=""" 
            + num.ToString()
            + @""" registry=""10646"" />"

        new CREPDLValidator(XElement.Load(new StringReader(crepdlScript)))
        
    [<TestCase(371,"\u8173", false)>]
    [<TestCase(372,"\u8173", false)>]
    [<TestCase(285,"\u8173", false)>]
    [<TestCase(286,"\u8173", false)>]
    [<TestCase(285,"\u3099", false)>]
    [<TestCase(285,"\u309A", false)>]
    [<TestCase(285,"\u3100", false)>]
    let testValidationAgainstCollection annexACollectionNumber str result  =
        let validator = createValidator annexACollectionNumber
        if result then Assert.True(validator.validateString str = ([||], [||]))
        else  Assert.False(validator.validateString str = ([||], [||]))