---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PlumbingUtils.PlaceCapOnOpenEnds(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/c47a8f0c-18fa-733a-02fb-2ca32e78f755.htm
---
# Autodesk.Revit.DB.Plumbing.PlumbingUtils.PlaceCapOnOpenEnds Method

Places caps on the open connectors of the pipe curve, pipe fitting or pipe accessory.

## Syntax (C#)
```csharp
public static void PlaceCapOnOpenEnds(
	Document document,
	ElementId elemId,
	ElementId typeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **elemId** (`Autodesk.Revit.DB.ElementId`) - Element id of pipe curve, pipe fitting or pipe accessory.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - Pipe type element id.
 Default is invalidElementId.

## Remarks
In order to place the cap, the cap type should be defined in the routing preferences that associates with the pipe type of the given element.
 If the typeId is a valid element id, it will be used to override the pipe type that associates with the pipe type of the given element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element elemId does not exist in the document
 -or-
 The element elemId is neither an object of pipe curve, pipe fitting, nor pipe accessory.
 -or-
 The element elemId has no opened piping connector.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - this operation failed.

