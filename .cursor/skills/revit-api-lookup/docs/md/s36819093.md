---
kind: method
id: M:Autodesk.Revit.DB.WorksetTable.SetActiveWorksetId(Autodesk.Revit.DB.WorksetId)
source: html/9f11d796-ca5c-93d9-51e1-67cf8da9baf2.htm
---
# Autodesk.Revit.DB.WorksetTable.SetActiveWorksetId Method

Sets the active workset.

## Syntax (C#)
```csharp
public void SetActiveWorksetId(
	WorksetId worksetId
)
```

## Parameters
- **worksetId** (`Autodesk.Revit.DB.WorksetId`) - The workset Id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There is no workset in the document with this id.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

