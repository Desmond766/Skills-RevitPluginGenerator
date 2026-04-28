---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.Reposition(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/551b269e-ee2e-d671-39f6-2aab7f027036.htm
---
# Autodesk.Revit.DB.FabricationPart.Reposition Method

Repositions the fabrication straight part to another end of the run.

## Syntax (C#)
```csharp
public static void Reposition(
	Document document,
	ElementId partId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **partId** (`Autodesk.Revit.DB.ElementId`) - Identifier of the fabrication part to reposition.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - It is not a straight segment on the end in the run.
 -or-
 There are locked parts in the run.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - this operation failed.

