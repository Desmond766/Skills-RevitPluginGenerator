---
kind: type
id: T:Autodesk.Revit.DB.Subelement
source: html/2d15bb45-70af-5f84-e899-322742591251.htm
---
# Autodesk.Revit.DB.Subelement

An object that represents an element or a subelement within the Autodesk Revit project.

## Syntax (C#)
```csharp
public class Subelement : IDisposable
```

## Remarks
Subelements provide a way for parts of an element to behave as though they were real elements without incurring the overhead of adding more full elements to the model. Many Revit features (for example parameters, schedules, and tags) were designed to operate on Elements.
 As a result, the Revit code needs to represent objects as Elements for them to participate in those features. This can lead to scalability problems,
 because every Element adds overhead and adding many Elements may decrease the performance of the model. An alternative is to use Subelements. An element
 can expose a set of "Subelements" that it contains, specifying characteristics like their category and parameters,
 and certain Revit capabilities will treat those Subelements the same as ordinary Elements. For example, a Subelement may contribute geometry to the main element
 and may be able to be selected independently of its parent Element. It will possibly have its own (settable) type as well as an assigned category which
 can be different from its parent Element. In the API, the new Subelement class is used to refer to either an Element or a specific subelement of a given Element.
 It is typically directly related to a Reference to either the Element or the specific subelement.
 Note that creation of new Subelements for a given element is not done generically. Instead, the given Element may provide the ability to modify it's definition,
 resulting in the creation of new Subelements. Examples of Elements which may have Subelements in practice include:
 RebarContainer Rebar FabricSheet Stairs elements which make up MultistoryStairs elements Railing [!:Autodesk::Revit::DB::Architecture::ContinuousRail] To get access to a particular Subelement, you may use any of the following:
 Create(Document, Reference) IsValidSubelementReference(Document, Reference) Autodesk.Revit.DB.Document.GetSubelement(Autodesk.Revit.DB.Reference) if you have a Reference to a Subelement. Autodesk.Revit.DB.Document.GetSubelement(String) if you have a unique id of a Subelement. GetSubelements () () ()

