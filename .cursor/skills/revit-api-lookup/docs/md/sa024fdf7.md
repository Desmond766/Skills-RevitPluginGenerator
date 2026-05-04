---
kind: method
id: M:Autodesk.Revit.DB.Architecture.StairsPath.CreateOnMultistoryStairs(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.LinkElementId,Autodesk.Revit.DB.ElementId)
source: html/033548f8-3bc0-1ebb-d11e-43c66cd42cec.htm
---
# Autodesk.Revit.DB.Architecture.StairsPath.CreateOnMultistoryStairs Method

Creates a new stairs path for the stairs in a multistory stairs with the specified stairs path type only in the plan view.

## Syntax (C#)
```csharp
public static IList<StairsPath> CreateOnMultistoryStairs(
	Document document,
	LinkElementId multistoryStairsId,
	ElementId typeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **multistoryStairsId** (`Autodesk.Revit.DB.LinkElementId`) - The id of the multistory stairs element either in the host document or in a linked document.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The type of stairs path.

## Returns
The new stairs paths.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Cannot add more stairs paths on multistoryStairsId.
 -or-
 The typeId is not a valid stairs path type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

