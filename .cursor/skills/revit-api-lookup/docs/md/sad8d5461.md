---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCExtrusionCreationData.AddOpening(Autodesk.Revit.DB.IFC.IFCExtrusionData)
source: html/55c7a07d-e4a0-2a58-1beb-2b858767265b.htm
---
# Autodesk.Revit.DB.IFC.IFCExtrusionCreationData.AddOpening Method

Adds an opening to the data.

## Syntax (C#)
```csharp
public void AddOpening(
	IFCExtrusionData data
)
```

## Parameters
- **data** (`Autodesk.Revit.DB.IFC.IFCExtrusionData`) - The opening.

## Remarks
The opening is stored for retrieval later via GetOpenings().

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

