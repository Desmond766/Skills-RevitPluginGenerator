---
kind: method
id: M:Autodesk.Revit.DB.Architecture.StairsPath.CanCreateOnMultistoryStairs(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.LinkElementId)
source: html/cb44257c-75cb-11cd-76c8-b1b477ea2a6d.htm
---
# Autodesk.Revit.DB.Architecture.StairsPath.CanCreateOnMultistoryStairs Method

Checks if more stairs paths can be added on the plan views of a multistory stairs.

## Syntax (C#)
```csharp
public static bool CanCreateOnMultistoryStairs(
	Document document,
	LinkElementId multistoryStairsId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`)
- **multistoryStairsId** (`Autodesk.Revit.DB.LinkElementId`) - The multistory stairs id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

