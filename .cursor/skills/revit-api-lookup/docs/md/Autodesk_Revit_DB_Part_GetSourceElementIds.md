---
kind: method
id: M:Autodesk.Revit.DB.Part.GetSourceElementIds
source: html/35943e3b-b8d2-2bd6-6258-27599d012ee8.htm
---
# Autodesk.Revit.DB.Part.GetSourceElementIds Method

Gets a collection of elements from which this Part is created by the PartMaker.
 May return more than one source only if there is merge involved somewhere in the history of this Part.

## Syntax (C#)
```csharp
public ICollection<LinkElementId> GetSourceElementIds()
```

## Returns
The collection of elements

## Remarks
A source element is one of the elements in the original file that the PartMaker uses to create a Part.
 For example, a floor or a wall used to create a Part can be called a source element.

