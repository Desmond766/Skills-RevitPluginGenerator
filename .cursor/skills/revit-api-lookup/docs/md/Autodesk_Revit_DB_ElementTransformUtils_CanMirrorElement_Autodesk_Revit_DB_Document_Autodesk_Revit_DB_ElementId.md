---
kind: method
id: M:Autodesk.Revit.DB.ElementTransformUtils.CanMirrorElement(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/c9f05388-ef04-303b-1046-c45f3a16b289.htm
---
# Autodesk.Revit.DB.ElementTransformUtils.CanMirrorElement Method

Determines whether element can be mirrored.

## Syntax (C#)
```csharp
public static bool CanMirrorElement(
	Document ADoc,
	ElementId elemId
)
```

## Parameters
- **ADoc** (`Autodesk.Revit.DB.Document`) - The document where the element reside.
- **elemId** (`Autodesk.Revit.DB.ElementId`) - The element identified by id.

## Returns
True if the element can be mirrored.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

